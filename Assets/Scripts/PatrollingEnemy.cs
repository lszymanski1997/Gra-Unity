using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    float movespeed = 25f;
    bool active;

    GameObject player;
    Rigidbody2D rb;
    Vector2 move;
    bool attCooldown;
    public float cooldown = 1f;
    public float hp;
    public GameObject gorePrefab;
    float attackDist = .6f;
    public GameObject hurtBox;
    public Transform attackpoint;
    private Transform[] patrolPoints;
    private int currentPointIndex;
    private Transform currentPoint;
    public Transform sprite;
    public Money moneyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        rb = this.GetComponent<Rigidbody2D>();
        hp = 100f;

        List<Transform> points = getUnsortedPatrolPoints();
        if (points.Count > 0)
        {
            patrolPoints = new Transform[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                Transform point = points[i];
                int closingParenthesisIndex = point.gameObject.name.IndexOf(")");
                string numberIndex = point.gameObject.name.Substring(13, closingParenthesisIndex - 13);
                int index = Convert.ToInt32(numberIndex);
                patrolPoints[index] = point;
                point.SetParent(null);
                point.gameObject.hideFlags = HideFlags.HideInHierarchy;
            }
            setCurrentPatrolPoint(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            GameObject gore = Instantiate(gorePrefab, transform.position, Quaternion.identity);
            Money money = Instantiate(moneyPrefab, transform.position, Quaternion.identity);
            money.setValue(UnityEngine.Random.Range(5, 10));
            Destroy(gameObject);
            Destroy(gore, 5f);
        }

        if (active == true)
        {
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            dir.Normalize();
            move = dir;
            moveEnemy(move);

            if ((Vector3.Distance(player.transform.position, transform.position)) <= attackDist)
            {
                if (!attCooldown)
                {
                    GameObject attack = Instantiate(hurtBox, attackpoint.position, attackpoint.rotation);
                    attCooldown = true;
                    Destroy(attack, .1f);

                }
                else
                {
                    cooldown -= Time.deltaTime;
                    if (cooldown <= 0)
                    {
                        attCooldown = false;
                        cooldown = 1f;
                    }

                }
            }
        }
        else if (active == false)
        {
            if(currentPoint != null)
            {
                Vector3 dir = currentPoint.position - sprite.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                dir.Normalize();
                move = dir;
                moveEnemy(move);
                if ((Vector3.Distance(transform.position, currentPoint.position)) <= .5f)
                {
                    if (currentPointIndex >= patrolPoints.Length - 1)
                    {
                        setCurrentPatrolPoint(0);
                    }
                    else
                    {
                        setCurrentPatrolPoint(currentPointIndex + 1);
                    }
                }
            }

        }


    }

    void moveEnemy(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * movespeed * Time.deltaTime));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            active = true;
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            hp = hp - bullet.getDamage();
            Vector3 dir = bullet.getStartPoint() - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    private List<Transform> getUnsortedPatrolPoints()
    {
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();
        var points = new List<Transform>();
        
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].gameObject.name.StartsWith("patrolPoint ("))
            {
                points.Add(children[i]);
            }
        }
        return points;
    }

    private void setCurrentPatrolPoint(int index)
    {
        currentPointIndex = index;
        currentPoint = patrolPoints[index];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float hp;
    public GameObject bloodSplatter;
    private bool dead = false;
    private Vector3 spawnPoint;
    private bool canMove = true;
    public Transform playerModel;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public HpDisplay healthbar;
    public AmmoCounter ammoCounter;
    private int ammo;
    private int money = 0;

    public float force = 5f;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100f;
        ammo = PlayerPrefs.GetInt("ammo", 0);
        ammoCounter.setText(ammo);
        healthbar.SetMaxVal(hp);
        spawnPoint = this.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        characterMove();
        mouseLook();
        if (Input.GetKeyDown(KeyCode.R))
        {
            respawn();
        }
        if (hp <= 0 && !dead)
        {
            death();
        }
        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            Shoot1();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 3f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 2f;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("ammo", ammo);

            SceneManager.LoadScene("Menu");
        }
            
    }

    public int getAmmo()
    {
        return ammo;
    }
    public void reload_ammo()
    {
        ammo = PlayerPrefs.GetInt("ammo", 0);
        ammoCounter.setText(ammo);
    }

    private void characterMove()
    {
        if (canMove)
        {
            var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            GetComponent<Rigidbody2D>().velocity = input.normalized * moveSpeed;
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<Rigidbody2D>().angularVelocity = 0;
            }
            if (Input.GetAxisRaw("Vertical") == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().angularVelocity = 0;
            }
        }
        
    }

    private void mouseLook()
    {
        if (canMove)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mousePos - GetComponent<Rigidbody2D>().position;
            float angle = -Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg;
            GetComponent<Rigidbody2D>().rotation = angle;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HurtBox")
        {
            hp -= 10;
            healthbar.SetValue(hp);
            GameObject blood = Instantiate(bloodSplatter, transform.position, transform.rotation);
            Destroy(blood, 2f);
        }
        else if (collision.tag == "Ammo")
        {
            ammo += 10;
            ammoCounter.setText(ammo);
            Destroy(collision.gameObject);
        }
        else if(collision.tag == "healthpack")
        {
            if (hp < 100)
            {
                hp += 30;
                healthbar.SetValue(hp);
                Destroy(collision.gameObject);
            }
            
        }
        else if(collision.tag == "Money")
        {
            Money mon = collision.GetComponent<Money>();
            addMoney(mon.getValue());
            Destroy(collision.gameObject);
        }
    }

    public void death()
    {
        if (!dead)
        {
            dead = true;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            canMove = false;
            playerModel.gameObject.SetActive(false);

        }
    }
    
    public void respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("ammo", 15);
        ammo = PlayerPrefs.GetInt("ammo", 0);
    }

    void Shoot1()
    {
        if (canMove)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * force, ForceMode2D.Impulse);
            ammo -= 1;
            ammoCounter.setText(ammo);
        }
    }

    public void addMoney(int val)
    {
        money += val;
    }
}

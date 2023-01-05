using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitPrefab;
    public float damage;
    private Vector3 startPoint;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = Instantiate(hitPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, .01f);
        Destroy(hit, .1f);
    }

    private void Update()
    {
        Destroy(gameObject, 2f);
    }

     public float getDamage()
    {
        return damage;
    }

    public void setDamage(float val)
    {
        damage = val;
    }

    public Vector3 getStartPoint()
    {
        return startPoint;
    }

    public void setStartPoint(Vector3 point)
    {
        startPoint = point;
    }
}

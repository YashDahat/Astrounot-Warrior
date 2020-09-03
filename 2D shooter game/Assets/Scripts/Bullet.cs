using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float speed = 50f;
    public int damage = 40;
    public GameObject shootani;
    void Start()
    {
        bullet.velocity = transform.right * speed;
    }

 
    //private void OnTriggerEnter2D(Collider2D collision)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.transform.GetComponent<Enemy>();
        Octopus octopus = collision.transform.GetComponent<Octopus>();
        if (enemy != null)
        {
            enemy.Takedamage(damage);
        }
        else if (octopus != null)
        {
            octopus.Takedamage(damage);
        }
        else if (collision.gameObject.tag == "pickup")
        {
            collision.transform.gameObject.GetComponent<Pickup>().destroystone(damage);
        }
        Instantiate(shootani, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}



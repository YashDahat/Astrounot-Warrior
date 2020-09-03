using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10000;
    public GameObject enemy;
    public GameObject enemydestroy;
    Transform player;
    bool isflipped = false;
    bool Obstaclecollision = false;
    bool playercollison = false;
    public bool died = false; 

    public int playerdamage = 10;
    
    public  void Takedamage(int damage)
    {
        if (health <= 0)
        {
            //GetComponent<Animator>().SetBool("destroy", true);
            killed(); 
            Die();

        }
        else
        {
            health -= damage;
        }
    }
    void Die()
    {
        
        Instantiate(enemydestroy, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void killed()
    {
        died = true;
        //return died;
    }
     void Update()
    {
        //enemydestroy.SetActive(false);
        //Flipped();
    }
    public void Flipped()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        Vector3 flip = transform.localScale;
        flip.z *= -1f; 
        if ((enemy.transform.position.x > player.position.x) && isflipped)
        {
            transform.localScale = flip;
            enemy.transform.Rotate(0f, 180f, 0f);
            isflipped = false;
        }
        else if (enemy.transform.position.x < player.position.x && !isflipped)
        {
            transform.localScale = flip;
            enemy.transform.Rotate(0f, 180f, 0f);
            isflipped = true;

        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    
        //if (collision.transform.tag != "Player")
        
          //  Obstaclecollision = true;
                //else
        
           // Obstaclecollision = false;
        
    
    //public bool Obstacledetected()
    
       // return Obstaclecollision;
    

    
}

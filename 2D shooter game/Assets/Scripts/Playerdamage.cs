using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerdamage : MonoBehaviour
{
    public float damage = 5f;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {

     
        playermovement player = collision.gameObject.GetComponent<playermovement>();
        if (player != null)
        {
           player.Playerdamage(damage);
           
        }
    }
}

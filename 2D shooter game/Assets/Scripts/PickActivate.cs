using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickActivate : MonoBehaviour
{
    GameObject powerup;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "player")
        {
           
             playermovement player = collision.gameObject.GetComponent<playermovement>();
            powerup = Instantiate(player.poweruppl, player.transform.position, player.transform.rotation);
            player.stage += 1;
            switch (player.stage)
            {
                case 1:
                    player.runspeed += 20;
                    player.playerhealth += 100;
                    break;
                case 2:
                    player.runspeed += 30;
                    player.playerhealth += 500;
                    break;

                default:
                    player.stage = 2;
                    break;
            }
            Destroy(gameObject);
            Destroy(powerup);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int breakdown = 200;
    bool status=false;
    public GameObject powerupani;
    //playermovement player;
    
    public void destroystone(int damage)
    {
        if (breakdown <= 0)
        {
            Instantiate(powerupani,transform.position, transform.rotation);
            Destroy(gameObject);
            //return status;
        }
        else
        {
            breakdown -= damage;
            //return !status;
        }
        
    }
}

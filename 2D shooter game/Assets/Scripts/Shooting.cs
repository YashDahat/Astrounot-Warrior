using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject shootani;
    public int damage=40;
    public LineRenderer line;
    //bool status=false;
    //public GameObject bullet;
    //void Update()
    //{
        //if (Input.GetButton("Fire1"))
    //    {
          // Shoot();
    //    }
    //}
    private void FixedUpdate()
    {
        GetComponent<Animator>().SetBool("shoot", false);
        line.enabled = false;
    }
    //public void Shoot()
    //{
    //    GetComponent<Animator>().SetBool("shoot", true);
    //    Instantiate(bullet, firepoint.position, firepoint.rotation);
    //}
    public void Shoot()
    {

    RaycastHit2D hitinfo =Physics2D.Raycast(firepoint.position, firepoint.right);

      if (hitinfo)
      {
        Enemy enemy=hitinfo.transform.GetComponent<Enemy>();
        Octopus octopus = hitinfo.transform.GetComponent<Octopus>();
        if (enemy != null)
        {
            enemy.Takedamage(damage);


        }
        else if (octopus != null)
        {
            octopus.Takedamage(damage);
        }
        else if (hitinfo.transform.gameObject.tag == "pickups")
        {
            hitinfo.transform.gameObject.GetComponent<Pickup>().destroystone(damage);
            //Debug.Log(status);
       }
        Instantiate(shootani, hitinfo.point, Quaternion.identity);//Quaternion.identity:fancy way of showing no rotation
      }

        GetComponent<Animator>().SetBool("shoot", true);
        line.SetPosition(0, firepoint.position);
        line.SetPosition(1, hitinfo.point);
        line.enabled = true;


    }

}

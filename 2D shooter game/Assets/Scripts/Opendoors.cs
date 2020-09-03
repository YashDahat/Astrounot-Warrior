using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opendoors : MonoBehaviour
{
    public bool Doorsopen=false;
    public Database db;
    public bool Open()
    {
        Doorsopen = true;
        gameObject.GetComponent<Animator>().SetBool("bosskilled", true);
        return Doorsopen;
        //return true;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (Doorsopen)
            {
                db.Loadnextlevel();
            }
        }
    }

}

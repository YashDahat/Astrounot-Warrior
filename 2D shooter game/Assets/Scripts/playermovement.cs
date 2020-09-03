using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermovement : MonoBehaviour
{
    
    public float runspeed=40f ;
    float horizontalMove = 0f;
    public Transform shootingpoint;
    public float playerhealth = 100f;
    public HealthBar value;

    bool jump = false,duck=false,shootup=false;
    public GameObject playerdesanim;
    public GameObject poweruppl;
    public int stage=0;
    //public Opendoors door1, door2;

    public Joystick joystick;
    private void Start()
    {
        value.Setmax(playerhealth);
    }
    private void Update()
    {

        if (joystick.Horizontal >= 0.2f)
        {
            horizontalMove = joystick.Horizontal*runspeed;
        }
        else if (joystick.Horizontal <= -0.2f)
        {
            horizontalMove = joystick.Horizontal*runspeed;
        }
        else
        {
            horizontalMove = 0;
        }
        GetComponent<CharacterController2D>().Move(horizontalMove * Time.deltaTime, false, jump);
        GetComponent<Animator>().SetFloat("speed", Mathf.Abs(horizontalMove));



        Vector3 updaterotation = new Vector3(0f, 0f, 90f);
        Vector3 originalposition = new Vector3(0f, 0f, 0f);

        if (joystick.Vertical <= -0.5f)
        {
            duck = true;
            GetComponent<Animator>().SetBool("duck", duck);
            //shootingpoint.Rotate(0f, 0f, -90f);
            shootingpoint.eulerAngles = -updaterotation; 
        }
        else if (joystick.Vertical >= 0.5f)
        {
            shootup = true;
            GetComponent<Animator>().SetBool("shootup", shootup);
            //shootingpoint.Rotate(0f, 0f, 90f);
            shootingpoint.eulerAngles = updaterotation;
        }
        else
        {
            if (duck)
            {
                duck = false;
                GetComponent<Animator>().SetBool("duck", duck);
                //shootingpoint.Rotate(0f, 0f, 90f);
                shootingpoint.eulerAngles =originalposition ;
            }
            else if (shootup)
            {
                shootup = false;
                GetComponent<Animator>().SetBool("shootup", shootup);
                //shootingpoint.Rotate(0f, 0f, -90f);
                shootingpoint.eulerAngles = originalposition;
            }
        }
     value.Healthbar(playerhealth);
}
    // public void OnLanding()
    //{
    //  GetComponent<Animator>().SetBool("isjumping", false);
    //}
    private void FixedUpdate()
    {
        //GetComponent<CharacterController2D>().Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        GetComponent<CharacterController2D>().Move(horizontalMove*Time.deltaTime, false, jump);
        GetComponent<Animator>().SetBool("jump", jump);
        // if (Input.GetButtonUp("Jump"))
        horizontalMove =0f;
        GetComponent<CharacterController2D>().Move(horizontalMove * Time.deltaTime, false, jump);
        GetComponent<Animator>().SetFloat("speed", Mathf.Abs(horizontalMove));
        
        //jump = false;
        //GetComponent<Animator>().SetBool("jump", jump);        


           // if (joystick.Vertical>=-0.2f)
           // {
           //     duck = false;
           //     GetComponent<Animator>().SetBool("duck", duck);
           //     shootingpoint.Rotate(0f, 0f, 90f);
           // }

           // else if(joystick.Vertical<=0.2f)
           // {
           //     shootup = false;
           //     GetComponent<Animator>().SetBool("shootup", shootup);
           //     shootingpoint.Rotate(0f, 0f, -90f);
           // }

      
    }

    public void Playerdamage(float damage)
    {
        Debug.Log("player detected");
        if (playerhealth <= 0)
        {
            Die();
        }
        else
        {
            playerhealth -= damage;
        }
       
    }

    public void Die()
    {
        Instantiate(playerdesanim, transform.position, transform.rotation);
        gameObject.SetActive(false);
      
    }
    //private void OnCollisionEnter2D(Collision2D collision)     //activate next level if doorsopen is true
    //{
    //    if (door1.doorsopen)
    //    {
    //        if(collision.gameObject.tag=="doors")
    //        {
    //            Debug.Log("doorsareopen");
    //        }
    //    }
    //}
    public void Playerjump()
    {
        jump = true;
        GetComponent<CharacterController2D>().Move(0, false, jump);
        GetComponent<Animator>().SetBool("jump", jump);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusRun : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 20f;
    public float rangex = 5f;
    public float rangey = 5f;
    //static Vector2 originalpos;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
       // originalpos = new Vector2(rb.transform.position.x, rb.transform.position.y);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Mathf.Abs(player.transform.position.x - rb.position.x) <= rangex && Mathf.Abs(rb.position.y - player.position.y) <= rangey)
        {
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newpos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newpos);
            rb.GetComponent<Octopus>().Flipped();
        }
        //else
        {
            //animator.SetBool("idle", true);
        }
        //if (rb.GetComponent<Enemy>().Obstacledetected())
        {
            //Vector2 newpos = Vector2.MoveTowards(rb.position, originalpos, speed * Time.deltaTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRun : StateMachineBehaviour
{
    
public float speed = 2.5f;
Transform player;
Rigidbody2D rb;
Transform bossPos;
private combat playerHP;
private float timer=0;
public float nect;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<combat>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        bossPos =  animator.GetComponent<Transform>();
    //    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        
        if ((Vector2.Distance(target, new Vector2(bossPos.position.x, bossPos.position.y)) < 1.1) && (timer-nect  > 560)){
           Debug.Log(combat.playerHealth -= 1);
            nect= timer;
           Debug.Log(GameObject.FindGameObjectWithTag("Player"));
        }
        timer+=1;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

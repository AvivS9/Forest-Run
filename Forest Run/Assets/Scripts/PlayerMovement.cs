using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : StateMachineBehaviour
{
    GameObject player;
    private float forwardSpeed = 30f;
    private Rigidbody rigidbody;
    private float sideForce = 8f;
    private float jumpForce = 6f;

    private ButtonPress LeftBtn, RightBtn, JumpBtn;

    private bool onGround = true;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject;
        rigidbody = player.GetComponent<Rigidbody>();


        LeftBtn = GameObject.Find("LeftBtn").GetComponent<ButtonPress>();
        RightBtn = GameObject.Find("RightBtn").GetComponent<ButtonPress>();
        JumpBtn = GameObject.Find("JumpBtn").GetComponent<ButtonPress>();

        #region error checks
        if (rigidbody == null)
        {
            Debug.Log("no rigidbody on player");
        }
        if (LeftBtn == null)
        {
            Debug.Log("couldn't find left button");
        }
        if (RightBtn == null)
        {
            Debug.Log("couldn't find right button");
        }
        if (JumpBtn == null)
        {
            Debug.Log("couldn't find jump button");
        }
        #endregion
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveForward();
        
        if (LeftBtn.buttonPressed && PlayerManager.instance.onGround)
        {
            moveLeft();
        }
        if (RightBtn.buttonPressed && PlayerManager.instance.onGround)
        {
            moveRight();
        }
        if (JumpBtn.buttonPressed && PlayerManager.instance.onGround)
        {
            jump();
        }
    }

    

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
    
    public void moveForward()
    {
        player.transform.Translate(0, 0, forwardSpeed * Time.deltaTime);

    }

    public void moveLeft()
    {
        player.transform.Translate(-sideForce * Time.deltaTime, 0, 0);
        //rigidbody.AddForce(-sideForce * Time.deltaTime, 0, 0);
    }

    public void moveRight()
    {
        player.transform.Translate(sideForce * Time.deltaTime, 0, 0);
        //rigidbody.AddForce(sideForce * Time.deltaTime, 0, 0);
    }

    public void jump()
    {
        PlayerManager.instance.onGround = false;
        rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

    
}

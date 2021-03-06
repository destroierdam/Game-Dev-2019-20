﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Controls;
using static StateMacineUtil;

public class IdleState : StateMachineBehaviour
{
    private Animator animator;
    private MovementController movementController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = animator;
        movementController = animator.GetComponent<MovementController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateMacineUtil.DoMove(animator, movementController);
        if (Input.GetKeyDown(upKey))
        {
            movementController.Jump();
            if (movementController.IsOnLadder)
            {
                animator.SetBool("IsClimbing", true);
                animator.SetBool("IsJumping", false);
            }
            else
            {
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsClimbing", false);
            }
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
}

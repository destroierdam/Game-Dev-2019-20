using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Controls;
using static UnityEngine.Mathf;

public class StateMacineUtil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void DoMove(Animator animator, MovementController movementController)
    {
        float horizontalMoveDirection = Input.GetAxisRaw(Controls.HorizontalMovementAxis);
        movementController.SetHorizontalMoveDirection(horizontalMoveDirection);
        animator.SetFloat("NormalizedSpeed", Abs(horizontalMoveDirection));
        animator.SetBool("IsMoving", horizontalMoveDirection != 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Controls;

public class Attacks : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetInteger("AttackType", 1);
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttacking = Input.GetKeyDown(Controls.attackKey);
        bool freezeAttack = Input.GetKeyDown(Controls.freezeAttackKey);
        bool breakAttack = Input.GetKeyDown(Controls.breakAttackKey);
        if (freezeAttack) {
            this.animator.SetInteger("AttackType", 1);
        } else if (breakAttack) {
            this.animator.SetInteger("AttackType", 2);
        }
        this.animator.SetBool("Attacking", isAttacking);
    }
}

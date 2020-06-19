using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Controls;

public class Attacks : MonoBehaviour
{
    [SerializeField]
    private float attackRange = 2;
    private Animator animator;
    private MovementController movementController;
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.animator.SetInteger("AttackType", 1);
        this.movementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttacking = Input.GetKeyDown(Controls.attackKey);
        if (isAttacking)
        {
            Attack();
        }
        
    }
    private void Attack()
    {
        bool freezeAttack = Input.GetKeyDown(Controls.freezeAttackKey);
        bool breakAttack = Input.GetKeyDown(Controls.breakAttackKey);
        if (freezeAttack)
        {
            this.animator.SetInteger("AttackType", 1);
        }
        else if (breakAttack)
        {
            this.animator.SetInteger("AttackType", 2);
        }
        this.animator.SetBool("Attacking", true);

        Shoot();
    }
    private void Shoot()
    {
        int mask = LayerMask.GetMask("Enemy");
        Vector3 origin = this.transform.position;
        Vector3 direction = new Vector3(movementController.LookDirection(), 0);
        RaycastHit2D hitInfo = Physics2D.Raycast(origin,
                                                 direction,
                                                 attackRange,
                                                 mask);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                var enemy = hitInfo.collider.gameObject.GetComponent<EnemyLifecycleController>();
                if (enemy != null)
                {
                    enemy.Shot();
                }
            }
        }
    }
}

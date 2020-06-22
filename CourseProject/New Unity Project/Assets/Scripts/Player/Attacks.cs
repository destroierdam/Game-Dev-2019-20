using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Controls;

public class Attacks : MonoBehaviour
{
    [SerializeField]
    private float attackRange = 2f;
    [SerializeField]
    private float kickRange = 0.2f;
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
        ResolveAttackType();
        bool isAttacking = Input.GetKeyDown(Controls.attackKey);
        if (isAttacking)
        {
            Attack();
        }

    }
    private void ResolveAttackType()
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
    }
    private void Attack()
    {
        this.animator.SetBool("Attacking", true);

        switch (this.animator.GetInteger("AttackType"))
        {
            case 1:
                Shoot();
                break;
            case 2:
                Kick();
                break;
            default:
                Debug.LogError("Unknown attack type");
                break;
        }
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
    private void Kick()
    {
        int mask = LayerMask.GetMask("Destructable Walls");
        Vector3 origin = this.transform.position;
        Vector3 direction = new Vector3(movementController.LookDirection(), 0);
        RaycastHit2D hitInfo = Physics2D.Raycast(origin,
                                                 direction,
                                                 kickRange,
                                                 mask);
        if (hitInfo.collider != null)
        {
            hitInfo.collider.gameObject.SetActive(false);
        }
    }
}

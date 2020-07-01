using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyLifecycleController : MonoBehaviour
{
    [SerializeField]
    private int killedTime = 5;
    private Animator animator;
    private EnemyMovementController movementController;
    private Rigidbody2D rigidBody;
    private bool isFrozen;
    public bool IsFrozen { get => isFrozen; }
    void Start()
    {
        animator = GetComponent<Animator>();
        movementController = GetComponent<EnemyMovementController>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
    public void Shot()
    {
        Die();
        StartCoroutine(Revive(killedTime));
    }
    private void Die()
    {
        animator.SetBool("Frozen", true);
        movementController.isMoving = false;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        isFrozen = true;
    }
    private IEnumerator Revive(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("Frozen", false);
        movementController.isMoving = true;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        isFrozen = false;
    }
}

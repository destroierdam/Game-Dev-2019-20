using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyLifecycleController : MonoBehaviour
{
    [SerializeField]
    private int killedTime = 5;
    private Animator animator;
    private EnemyMovementController movementController;
    void Start()
    {
        animator = GetComponent<Animator>();
        movementController = GetComponent<EnemyMovementController>();
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
    }
    private IEnumerator Revive(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("Frozen", false);
        movementController.isMoving = true;
    }
}

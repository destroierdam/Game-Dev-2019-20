using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.58f;

    [SerializeField]
    private float distance = 1.46f;

    private float coveredDistance = 0;
    private Vector2 velocity = new Vector2(1, 0);
    private new Rigidbody2D rigidbody;
    void Start()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Debug.Log(coveredDistance);
        Move();
        if (coveredDistance >= distance)
        {
            SwapDirection();
            coveredDistance = 0;
        }
    }
    private void Move()
    {
        Vector2 newPosition = new Vector2
        {
            x = velocity.x * speed,
            y = velocity.y
        } * Time.fixedDeltaTime + rigidbody.position;
        rigidbody.MovePosition(newPosition);
        coveredDistance += Abs(velocity.x * speed * Time.fixedDeltaTime);
    }
    private void SwapDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        velocity.x = -velocity.x;
    }
}

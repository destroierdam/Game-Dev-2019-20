using UnityEngine;
using System;
using static UnityEngine.Mathf;
using UnityEditor.Experimental.AssetImporters;
//using System.Numerics;

public class MovementController : MonoBehaviour
{

	[SerializeField]
	[Range(0, 5)]
	private float horizontalMoveSpeed = 2;

	[SerializeField]
	[Range(0, 5)]
	private float verticalMoveSpeed = 1;

	[SerializeField]
	[Range(1, 5)]
	public float gravity = 5f;

	private float originalGravity;
	public bool IsAirborne { get; set; } = false;
	public bool IsOnLadder { get; set; } = false;
	private readonly float movementThreshold = 0.01f;

	[SerializeField]
	[Range(1, 5)]
	private float jumpVelocity = 2.3f;

	[SerializeField]
	[Range(1, 5)]
	private float climbVelocity = 2f;

	private Vector2 velocity = Vector2.zero;
	public Vector2 Velocity { get => velocity; }

	private new Rigidbody2D rigidbody;
	private Animator animator;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		originalGravity = gravity;
	}
	void FixedUpdate()
	{
		ResolveLookDirection();
		Move();
		if (IsAirborne)
		{
			Fall();
		}
	}
	private void Move()
	{
		float verticalVelocity = velocity.y;
		if (IsOnLadder)
		{
			verticalVelocity = velocity.y * climbVelocity;
		} 

		Vector2 newPosition = new Vector2
		{
			x = velocity.x * horizontalMoveSpeed,
			y = verticalVelocity
		} * Time.fixedDeltaTime + rigidbody.position;
		rigidbody.MovePosition(newPosition);
	}
	private void Fall()
	{
		velocity.y -= gravity * Time.deltaTime;
	}
	public void SetHorizontalMoveDirection(float amount)
	{
		velocity.x = amount;
	}
	public void SetVerticalMoveDirection(float amount)
	{
		velocity.y = amount;
		if (!IsOnLadder)
		{
			velocity.y *= jumpVelocity;
		}
	}
	public void Jump()
	{
		if (!IsOnLadder) { 
			velocity.y = jumpVelocity;
			IsAirborne = true;
		}
	}
	private void ResolveLookDirection()
	{
		if (Abs(velocity.x) > movementThreshold)
		{
			transform.localScale = new Vector3(Sign(velocity.x), 1, 1);
		}
	}
	public void TurnTowards(float direction)
	{
		transform.localScale = new Vector3(Sign(direction), 1, 1);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			IsAirborne = false;
			// OnJumpEnded?.Invoke();
			velocity.y = 0;
			animator.SetBool("IsJumping", false);
		} 
		if (collision.gameObject.CompareTag("Ladder"))
		{
			animator.SetBool("IsClimbing", true);
			Debug.Log("Player entering ladder");
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ladder"))
		{
			animator.SetBool("IsClimbing", false);
			Debug.Log("Player entering ladder");
		}
	}
	public void hasEnteredLadder()
	{
		originalGravity = gravity;
		gravity = 0f;
		IsOnLadder = true;
		Debug.Log("has entered ladder");
		animator.SetBool("IsClimbing", true);
	}
	public void hasExitedLadder()
	{
		gravity = originalGravity;
		IsOnLadder = false;
		Debug.Log("has exited ladder");
		animator.SetBool("IsClimbing", false);
	}
	public float LookDirection()
	{
		return transform.localScale.x;
	}
}
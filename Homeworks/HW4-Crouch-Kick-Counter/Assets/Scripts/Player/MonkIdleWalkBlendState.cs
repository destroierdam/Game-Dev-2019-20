using UnityEngine;
using static Controlls;
using static StateMachineUtil;

public class MonkIdleWalkBlendState : StateMachineBehaviour {

	private Animator animator;
	private MovementController movementController;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		this.animator = animator;
		movementController = animator.GetComponent<MovementController>();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		DoMove(animator, movementController);

		if (Input.GetKeyDown(attackKey)) {
			AIIsDodging();
			animator.SetTrigger("IsPunching");
		}
		if (Input.GetKeyDown(jumpKey)) {
			animator.SetBool("IsJumping", true);
			movementController.Jump();
		}
	}

	private void AIIsDodging() {
		GameObject AIGameObject = GameObject.FindWithTag("AI");
		if (AIGameObject == null) {
			Debug.LogError("No GameObject with the \"AI\" tag found");
			return;
		}
		Animator AIAnimator = AIGameObject.GetComponent<Animator>();

		if (AIAnimator == null) {
			Debug.LogError("AI GameObject does not have \"Animator\" component");
			return;
		}

		float rand = Random.value;
		if (rand < 0.4f)
		{
			AIAnimator.SetTrigger("ShouldDodge");
		}
	}
}

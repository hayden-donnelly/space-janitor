using System.Collections;
using UnityEngine;

public class PlayerDodging : BaseState 
{
	// TODO maybe implement i-frames
	[SerializeField] private float dodgeSpeed;
	[SerializeField] private float dodgeTime;
	[SerializeField] private float dodgeCooldown;
	private Vector2 dodgeVector;
	private bool isDodging;

	public override void Construct()
	{
		// TODO polish dodge
		dodgeVector = motor.InputVector;
		dodgeVector *= dodgeSpeed;
		dodgeVector *= Time.deltaTime;
		StartCoroutine(DodgeTimer());
	}

	public override void Destruct()
	{
		StartCoroutine(StateCooldown(dodgeCooldown));
	}

	public override void Transition()
	{
		if(!isDodging)
		{
			motor.ChangeState("PlayerWalking");
		}
	}

	// Ignores frame by frame input
	public override Vector2 ProcessMotion(Vector2 input)
	{
		return dodgeVector;
	}

	// Ignores frame by frame input
	public override Vector2 ProcessRotation()
	{
		return motor.LookDirection;
	}

	private IEnumerator DodgeTimer()
	{
		isDodging = true;
		yield return new WaitForSeconds(dodgeTime);
		isDodging = false;
	}
}

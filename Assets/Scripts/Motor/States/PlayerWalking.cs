using UnityEngine;

public class PlayerWalking : BaseState 
{
	[SerializeField] private float moveSpeed;

	public override void Transition()
	{
		if(Input.GetButtonDown("Dodge"))
		{
			motor.ChangeState("PlayerDodging");
		}
		else if(Input.GetButtonDown("Vacuum"))
		{
			motor.ChangeState("PlayerVacuuming");
		}
	}

	public override Vector2 ProcessMotion(Vector2 input)
	{
		input *= moveSpeed;
		input *= Time.deltaTime;
		return input;
	}
}
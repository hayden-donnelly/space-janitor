using UnityEngine;

public class PlayerVacuuming : BaseState 
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private GameObject vacuumCollider;
 	
	public override void Construct()
	{
		vacuumCollider.SetActive(true);
	}

	public override void Destruct()
	{
		vacuumCollider.SetActive(false);
	}

	public override void Transition()
	{
		if(Input.GetButtonDown("Dodge"))
		{
			motor.ChangeState("PlayerDodging");
		}
		else if(Input.GetButtonUp("Vacuum"))
		{
			motor.ChangeState("PlayerWalking");
		}
	}

	public override Vector2 ProcessMotion(Vector2 input)
	{
		input *= moveSpeed;
		input *= Time.deltaTime;
		return input;
	}

	public override void ProcessAbilities()
	{
		Vacuum();
	}

	private void Vacuum()
	{
		// TODO implement this!
	}
}

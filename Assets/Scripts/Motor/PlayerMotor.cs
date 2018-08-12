using UnityEngine;

public class PlayerMotor : BaseMotor
{
	public override void Start()
	{
		base.Start();
		state = GetComponent<PlayerWalking>();
		state.Construct();
	}

	protected override void UpdateMotor()
	{
		Vector2 input = PoolInput();
		InputVector = input;
		MoveVector = input;
		base.UpdateMotor();
	}

	private Vector2 PoolInput()
	{
		Vector2 dir = Vector3.zero;

		dir.x = Input.GetAxisRaw("Horizontal");
		dir.y = Input.GetAxisRaw("Vertical");

		if(dir.sqrMagnitude > 1)
		{
			dir.Normalize();
		}

		return dir;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Bullet")
		{
			GameManager.instance.PlayerHealth -= 1;
			GameManager.instance.UpdatePlayerHealth();
		}
	}
}

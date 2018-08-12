using UnityEngine;

public class TurretEnemy01 : BaseEnemy 
{
	private void Update()
	{	
		CheckTargetInRange();
		if(targetInRange)
		{
			LookAtTarget();

			if(isReadyToFire)
			{
				Fire();
			}
		}
	}

	private void LookAtTarget()
	{
		Vector2 lookDirection = transform.position - target.position;
		transform.up = -lookDirection;
	}

	private void Fire()
	{
		GameObject newBullet = Instantiate(bullet);
		newBullet.transform.position = transform.position;
		newBullet.transform.up = transform.up;
		StartCoroutine(ShotCooldown());
	}
}

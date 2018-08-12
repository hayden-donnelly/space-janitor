using System.Collections;
using UnityEngine;

public class BaseEnemy : MonoBehaviour 
{
	[SerializeField] protected float aggroRange;
	[SerializeField] protected GameObject bullet;
	[SerializeField] protected float shotCooldown;
	protected Transform target;
	protected bool targetInRange;
	protected bool isReadyToFire;

	protected virtual void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		isReadyToFire = true;
		targetInRange = false;
	}

	protected void CheckTargetInRange()
	{
		float distanceToTarget = Vector3.Distance(transform.position, target.position);
		if(distanceToTarget <= aggroRange)
		{
			targetInRange = true;
		}
		else
		{
			targetInRange = false;
		}
	}

	protected IEnumerator ShotCooldown()
	{
		isReadyToFire = false;
		yield return new WaitForSeconds(shotCooldown);
		isReadyToFire = true;
	}
}

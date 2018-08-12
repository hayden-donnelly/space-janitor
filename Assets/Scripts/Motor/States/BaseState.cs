using System.Collections;
using UnityEngine;

public class BaseState : MonoBehaviour 
{
	public bool unlocked = true;

	protected BaseMotor motor;
	protected float startTime;
	protected float immuneTime;

	private void Awake()
	{
		motor = GetComponent<BaseMotor>();
	}

	public virtual void Construct()
	{
		startTime = Time.time;
	}

	public virtual void Destruct()
	{

	}

	public virtual void Transition()
	{
		if(Time.time - startTime < immuneTime)
		{
			return;
		}
	}

	public virtual Vector2 ProcessMotion(Vector2 input)
	{
		Debug.LogWarning("Process Motion not implemented in " + this.ToString());
		return Vector3.zero;
	}

	public virtual Vector2 ProcessRotation()
	{
		return MotorHelper.DirectionToCursor(transform.position, motor.MainCamera);
	}

	public virtual void ProcessAnimation(Animator animator)
	{
		// TODO implement this
	}

	public virtual void ProcessAbilities()
	{
		
	}

	protected IEnumerator StateCooldown(float time)
	{
		unlocked = false;
		yield return new WaitForSeconds(time);
		unlocked = true;
	}
}

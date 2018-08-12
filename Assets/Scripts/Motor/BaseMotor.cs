using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMotor : MonoBehaviour 
{
	protected BaseState state;
	protected BaseState[] availableStates;
	protected Rigidbody2D rb2d;
	protected Animator anim;

	// Properties
	public Camera MainCamera { get; set; }
	public Vector3 InputVector { get; set; }
	public Vector2 LookDirection { get; set; }
	public Vector2 MoveVector { get; set; }

	public virtual void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		MainCamera = Camera.main;
		availableStates = GetComponents<BaseState>();
	}

	private void Update()
	{
		UpdateMotor();
	}

	protected virtual void UpdateMotor()
	{
		MoveVector = state.ProcessMotion(MoveVector);
		LookDirection = state.ProcessRotation();
		state.ProcessAbilities();
		state.Transition();
		Move();
		Rotate();
	}

	public virtual void Move()
	{
		rb2d.velocity = MoveVector;
	}

	public virtual void Rotate()
	{
		transform.up = LookDirection;
	}

	public virtual void ChangeState(string stateName)
	{
		foreach(BaseState s in availableStates)
		{
			if(s.GetType().FullName != stateName)
			{
				continue;
			}

			if(s.unlocked)
			{
				state.Destruct();
				state = s;
				state.Construct();
			}
			return;
		}

		Debug.LogWarning("New state could not be found");
	}

	public virtual void ChangeState(BaseState s)
	{
		state.Destruct();
		state = s;
		state.Construct();
	}
}
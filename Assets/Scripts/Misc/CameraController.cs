using UnityEngine;

public class CameraController : MonoBehaviour 
{
	[SerializeField] private Vector3 cameraOffset;
	private Transform target;

	private void Start()
	{
		 target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void LateUpdate()
	{
		transform.position = target.position + cameraOffset;
	}
}
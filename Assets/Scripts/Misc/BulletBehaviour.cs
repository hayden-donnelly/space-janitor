using UnityEngine;

public class BulletBehaviour : MonoBehaviour 
{
	[SerializeField] private float lifeSpan;
	[SerializeField] private float speed;

	private void Start()
	{
		Destroy(this.gameObject, lifeSpan);
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag != "Enemy" && col.tag != "Junk")
		{
			Destroy(this.gameObject);
		}
	}

	private void Update()
	{
		transform.Translate(0, speed * Time.deltaTime, 0);
	}
}

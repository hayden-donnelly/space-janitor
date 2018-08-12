using UnityEngine;

public class Vacuumable : MonoBehaviour 
{
	[SerializeField] private float vacuumTime;
	[SerializeField] private int scoreGain;
	private float vacuumTimer;

	private void Start()
	{
		vacuumTimer = vacuumTime;
	}

	private void OnTriggerStay2D(Collider2D col)
	{
		if(col.tag == "Vacuum")
		{
			vacuumTimer -= Time.deltaTime;
			if(vacuumTimer <= 0)
			{
				GameManager.instance.score += scoreGain;
				GameManager.instance.UpdateScore();
				Destroy(this.gameObject);
			}
		}
	}
}

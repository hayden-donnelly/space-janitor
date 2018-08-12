using UnityEngine;

public class FinishArea : MonoBehaviour 
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		print("Entered");
		if(col.tag == "Player")
		{
			GameManager.instance.GameSuccess();
		}
	}
}

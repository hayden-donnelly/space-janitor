using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static GameManager instance;	

	[SerializeField] private Text scoreText;
	[SerializeField] private Text healthText;
	[SerializeField] private GameObject GameFailureGraphic;
	[SerializeField] private GameObject GameSuccessGraphic;
	[SerializeField] private GameObject GameOverMenu;
	[SerializeField] private Text GameOverScoreDisplay;
	[SerializeField] private GameObject InGameUI;

	public int score = 0;
	public int PlayerHealth = 3;

	private void Start()
	{
		Time.timeScale = 1;
		instance = this;
		UpdatePlayerHealth();
		UpdateScore();
	}

	public void UpdatePlayerHealth()
	{
		healthText.text = "Health = " + PlayerHealth.ToString();

		if(PlayerHealth <= 0)
		{
			GameFailure();
		}
	}

	public void UpdateScore()
	{
		scoreText.text = "Score = " + score.ToString();
	}

	private void GameFailure()
	{
		GameOver();
		GameFailureGraphic.SetActive(true);
	}

	public void GameSuccess()
	{
		GameOver();
		GameSuccessGraphic.SetActive(true);
	}

	private void GameOver()
	{
		Time.timeScale = 0;
		GameOverMenu.SetActive(true);
		GameOverScoreDisplay.text = "Score = " + score.ToString();
		InGameUI.SetActive(false);
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHelper : MonoBehaviour 
{
	public void LoadScene(int index)
	{
		SceneManager.LoadScene(index);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}

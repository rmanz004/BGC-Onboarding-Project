using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
	public GameObject MainCanvas;
	public GameObject SettingsCanvas;
	public TextMeshProUGUI currDifficulty;
	public static float ghostSpeed = 2.0f;
	public static float ghostAcceleration = 8f;
	private void Start()
	{
		MainCanvas.SetActive(true);
		SettingsCanvas.SetActive(false);
	}

	public void ShowSettings()
	{
		MainCanvas.SetActive(false);
		SettingsCanvas.SetActive(true);
	}

	public void HideSettings()
	{
		MainCanvas.SetActive(true);
		SettingsCanvas.SetActive(false);
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void EasyDifficulty()
	{
		ghostSpeed = 1.5f;
		ghostAcceleration = 6f;
		currDifficulty.text = "Current Difficulty:\nEasy";
		Debug.Log("Easy selected");
    }

	public void MediumDifficulty()
	{
		ghostSpeed = 2.0f;
		ghostAcceleration = 8f;
		currDifficulty.text = "Current Difficulty:\nMedium";
		Debug.Log("Medium selected");
	}

	public void HardDifficulty()
	{
		ghostSpeed = 3.0f;
		ghostAcceleration = 10f;
		currDifficulty.text = "Current Difficulty:\nHard";
		Debug.Log("Hard selected");
	}

}

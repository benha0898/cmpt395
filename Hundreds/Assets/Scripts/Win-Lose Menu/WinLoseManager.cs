using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseManager : MonoBehaviour
{
    public GameObject WinMenu;
    public GameObject LoseMenu;

    public void GetWinMenu()
    {
        GameManager.TogglePause();
        GameObject menu = Instantiate(WinMenu, this.transform.position, Quaternion.identity, this.transform);
    }

    public void GetLoseMenu()
    {
        GameManager.TogglePause();
        GameObject menu = Instantiate(LoseMenu, this.transform.position, Quaternion.identity, this.transform);
    }

    public void LoadMainMenu()
    {
		GameManager.TogglePause();

		// When the player selects the Main Menu, allow them to enter their
		// highscore after Winning/Losing

        SceneManager.LoadScene("HighScoreEntry");
    }

    public void RestartLevel()
    {
		// Reset can only be done from Pause screen, which is paused
		GameManager.TogglePause();
        SceneManager.LoadScene("Countdown");
    }

    public void LoadNextLevel()
    {
		GameManager.TogglePause();
        GameManager.IncrementLevel();
        SceneManager.LoadScene("Countdown");
    }

    public void LoadScoreEntry()
    {
        GameManager.TogglePause();
        SceneManager.LoadScene("HighScoreEntry");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public UIManager UI;
    // Start is called before the first frame update
    void Start()
    {
        UI.GetComponentInChildren<Canvas>().enabled = false;
    }

    public void TogglePauseMenu()
    {
		GameManager.TogglePause();

		if (GameManager.isGamePaused()) {
            UI.GetComponentInChildren<Canvas>().enabled = true;
		} else {
            UI.GetComponentInChildren<Canvas>().enabled = false;
        }

        Debug.Log("GAMEMANAGER: : Timescale: " + Time.timeScale);
    }

    public void LoadMainMenu()
    {
		GameManager.TogglePause();
		GameManager.ResetGameLevel();
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartLevel()
    {
		// Reset can only be done from Pause screen, which is paused
		GameManager.TogglePause();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Update is called once per frame
    void Update()
    {

    }
}

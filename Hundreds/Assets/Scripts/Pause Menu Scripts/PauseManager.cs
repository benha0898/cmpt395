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
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1.0f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {

    }
}

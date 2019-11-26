using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadCountdown()
    {
        Debug.Log(this.gameObject.name);
        SceneManager.LoadScene("Countdown");
    }

    public void PlaySinglePayer()
    {
        GameManager.setCurrentGameScene("Endless Mode");
        SceneManager.LoadScene("Countdown");
    }

    public void PlayMultiPayer()
    {
        GameManager.setCurrentGameScene("Cooperative Mode");
        SceneManager.LoadScene("Countdown");
    }

    public void LoadHighscores()
    {
        SceneManager.LoadScene("Scores");
    }

}

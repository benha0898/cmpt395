using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadCountdown()
    {
        SceneManager.LoadScene("Countdown");
    }

    public void PlaySinglePayer()
    {
        SceneManager.LoadScene("Endless Mode");
    }

    public void PlayMultiPayer()
    {
        SceneManager.LoadScene("Cooperative Mode");
    }

    public void LoadHighscores()
    {
        SceneManager.LoadScene("Scores");
    }

}

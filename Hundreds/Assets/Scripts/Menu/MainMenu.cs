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
        GameObject.Find("gameManager").GetComponent<GameManager>().SceneName = "Endless Mode";
        SceneManager.LoadScene("Countdown");
    }

    public void PlayMultiPayer()
    {
        GameObject.Find("gameManager").GetComponent<GameManager>().SceneName = "Cooperative Mode";
        SceneManager.LoadScene("Countdown");
    }

    public void LoadHighscores()
    {
        SceneManager.LoadScene("Scores");
    }

}

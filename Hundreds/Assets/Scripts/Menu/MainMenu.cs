using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameManager GM;
    
    public void LoadCountdown()
    {
        Debug.Log(this.gameObject.name);
        SceneManager.LoadScene("Countdown");
    }

    public void PlaySinglePayer()
    {
        GM.setCurrentGameScene("Endless Mode");
        SceneManager.LoadScene("Countdown");
    }

    public void PlayMultiPayer()
    {
        GM.setCurrentGameScene("Cooperative Mode");
        SceneManager.LoadScene("Countdown");
    }


}

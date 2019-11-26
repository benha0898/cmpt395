using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown_Script : MonoBehaviour
{

    public float countdownTime;
    private TextMeshPro countdownText;
    public GameManager GM;


    // Start is called before the first frame update
    void Start()
    {

        countdownText = GetComponent<TextMeshPro>();
        countdownText.text = countdownTime.ToString("0");

    }

    // Update is called once per frame
    void Update()
    {
        //Check if the game is paused. If it is, unpause it 
        if (GameManager.isGamePaused())
            GameManager.TogglePause();

        // When the timer reaches 0, switch to endless mode 
        if (countdownTime <= 0)
        {
            SceneManager.LoadScene(GM.getCurrentGameScene());
        }

        countdownTime -= Time.deltaTime;
        countdownText.text = countdownTime.ToString("0");
    }
}


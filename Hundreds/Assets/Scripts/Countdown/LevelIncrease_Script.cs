using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelIncrease_Script : MonoBehaviour
{
    public float incrementLevel;
    private TextMeshPro LevelText;

    // Start is called before the first frame update
    void Start()
    {
        LevelText = GetComponent<TextMeshPro>();
        LevelText.text = incrementLevel.ToString("0");

    }

    // Update is called once per frame
    void Update()
    {
        //Check if the game is paused. If it is, unpause it 
        if (GameManager.isGamePaused())
            GameManager.TogglePause();

        incrementLevel = GameManager.GetGameLevel();
        LevelText.text = incrementLevel.ToString("0");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class FinalScoreScript : MonoBehaviour
{
    public int finalScore;
    private Text Final_Score_Text;
   // public int guiDepth = 0;
   
    GameObject additionPoints;

    // Start is called before the first frame update
    void Start()
    {
        //GUI.depth = guiDepth;

        //Using a text to diaplay to the screen instead of textMeshPro because 
        //the textMeshPro is not visible above the spawning balls. 
        Final_Score_Text = GetComponent<Text>();
        Final_Score_Text.text = finalScore.ToString("0");

        int getLevel;
        int multiplyLevel;

        int points;

        //Adding the level points 
        getLevel = GameManager.GetGameLevel();
        multiplyLevel = (getLevel * 100) - 100;

        //Grabbing the points calculation for that level 
        additionPoints = GameObject.Find("TotalPoints");
        points = int.Parse(additionPoints.GetComponent<TextMeshPro>().text);

        Debug.Log(points);

        finalScore = points + multiplyLevel;

        GameManager.SetFinalScore(finalScore);

        Debug.Log(GameManager.GetFinalScore());

        //Display final score 
        Final_Score_Text.text = finalScore.ToString("0");

        Debug.Log(Final_Score_Text);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/* Dedicated to the functionality of a Timer
 *	Should be attached to the TextMeshPro object of the timer
 */
public class SceneTimer : MonoBehaviour
{
	// TODO: Source Level time from Global Variables
	public float sceneTime;
	private TextMeshPro timerText;

    // Start is called before the first frame update
    void Start()
    {
		timerText = GetComponent<TextMeshPro>();
		timerText.text = sceneTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
		// TODO: Call Game Over scene
		if (sceneTime <= 0) {
			timerText.text= "Game Over!";
			return;
		}

		sceneTime -= Time.deltaTime;
		timerText.text = sceneTime.ToString("F2");
    }
}


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
	public float sceneTime;
	public WinLoseManager WLM;
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
		if (GameManager.isGamePaused())
			return;

		// When the Time is up, Show the Lose menu
		if (sceneTime <= 0) {
			WLM.GetLoseMenu();
			return;
		}

		sceneTime -= Time.deltaTime;
		timerText.text = sceneTime.ToString("F2");
    }
}

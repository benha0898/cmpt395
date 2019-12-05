using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* Gameplay will be paused after a PauseButton object is help for a specific
 * amount of time.
 */
public class GameplayPauseScript : MonoBehaviour
{
	private float clickedTime;
	private bool isClicked, lastFrameClicked;
	private PauseManager pauseManager;
	private float PauseDelay;
	private GameObject Bounds;
	private float incSize;
	private GameObject pauseText;

	void Start()
	{
		clickedTime = 0f;
		isClicked = false;
		lastFrameClicked = false;

		incSize = Time.deltaTime / 4;
	}

	// While enabled, count how long the pause button has been pressed.
	void Update()
	{
		if (GameManager.isGamePaused())
			return;

		// Return if the Object isn't Clicked
		if (!isClicked) {
			// Reset if the object was clicked last frame
			if (lastFrameClicked)
				reset();
			return;
		}

		Bounds.SetActive(true);
		pauseText.SetActive(true);

		pauseText.GetComponent<TextMeshPro>().text = "Pausing in " + ( PauseDelay - clickedTime + 1).ToString("0");

		clickedTime += Time.deltaTime;
		gameObject.transform.localScale += new Vector3(incSize, incSize, 0);

		if (clickedTime >= PauseDelay) {
			pauseText.SetActive(false);
			pauseManager.TogglePauseMenu();
			Debug.Log(gameObject.transform.localScale);
		}

		lastFrameClicked = true;
		isClicked = false;
	}

	// Method for Click Manager to set clicked option
	public void setClicked() { isClicked = true; }

	// Reset default
	void reset()
	{
		Bounds.SetActive(false);
		gameObject.transform.localScale = new Vector3(1,1,0);
		pauseText.SetActive(false);
		clickedTime = 0f;
	}

	// Set Reference to PauseManager so that we may pause the game.
	public void SetPauseManager(PauseManager p) { pauseManager = p; }

	// Set the delay before the game is paused
	public void SetPauseDelay(float delay) { PauseDelay = delay; }

	public void SetBoundObj(GameObject n) { Bounds = n;
		Bounds.transform.localScale += new Vector3(1f, 1f, 0);
	}

	public void SetPauseText(GameObject PauseText) {
		pauseText = PauseText;
	}
}

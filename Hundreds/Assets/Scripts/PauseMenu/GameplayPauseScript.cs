using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Gameplay will be paused after a PauseButton object is help for a specific
 * amount of time.
 */
public class GameplayPauseScript : MonoBehaviour
{
	private float clickedTime;
	private bool isClicked, lastFrameClicked;
	private PauseManager pauseManager;
	private float PauseDelay;

	void Start()
	{
		clickedTime = 0f;
		isClicked = false;
		lastFrameClicked = false;
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


		clickedTime += Time.deltaTime;
		gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0);

		if (clickedTime >= PauseDelay) {
			pauseManager.TogglePauseMenu();
		}

		lastFrameClicked = true;
		isClicked = false;
	}

	// Method for Click Manager to set clicked option
	public void setClicked() { isClicked = true; }

	// Reset default
	void reset()
	{
		gameObject.transform.localScale = new Vector3(1,1,0);
		clickedTime = 0f;
	}

	// Set Reference to PauseManager so that we may pause the game.
	public void SetPauseManager(PauseManager p) { pauseManager = p; }

	// Set the delay before the game is paused
	public void SetPauseDelay(float delay) { PauseDelay = delay; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Gameplay will be paused after a PauseButton object is help for a specific
 * amount of time.
 */
public class GameplayPauseScript : MonoBehaviour
{
	private float clickedTime;
	private bool isClicked;
	private PauseManager pauseManager;
	private float PauseDelay;

	void Start()
	{
		enabled = false;
		clickedTime = 0f;
	}

	// While enabled, count how long the pause button has been pressed.
	void Update()
	{
		if (GameManager.isGamePaused())
			return;

		clickedTime += Time.deltaTime;
		gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0);

		if (clickedTime >= PauseDelay) {
			pauseManager.TogglePauseMenu();
			enabled = false;
		}
	}
	/* Enable Update method to start counting, and disable to reset */

    void OnMouseDown()
    {
		enabled = true;
    }


	void OnMouseUp()
	{
		gameObject.transform.localScale = new Vector3(1,1,0);
		clickedTime = 0f;
		enabled = false;
	}

	// Set Reference to PauseManager so that we may pause the game.
	public void SetPauseManager(PauseManager p) { pauseManager = p; }

	// Set the delay before the game is paused
	public void SetPauseDelay(float delay) { PauseDelay = delay; }
}

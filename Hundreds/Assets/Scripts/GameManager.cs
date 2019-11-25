using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Responsible for managing all attributes that are maintained throughout all of
 * the levels
 */
public class GameManager : Singleton<GameManager>
{
	private static bool	GamePaused = false;
	private static int 	GameLevel = 1;
    public string SceneName;
    private static int finalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
		Debug.Log("Game Manager initialized");
    }

	/* Game Level Functions				*/

	// Return Current Game Level
	public static int 	GetGameLevel() { return GameLevel; }
	// Increment the Game Level
	public static void IncrementLevel() { GameLevel += 1; }
	// Reset Game Level to 1
	public static void ResetGameLevel() { GameLevel = 1; }

    public static int GetFinalScore() { return finalScore; }

    public static void SetFinalScore(int newFinalScore)
    {
        finalScore = newFinalScore;
    }

    /*		 Pause Functionality		*/

    // Return Game Paused boolean
    public static bool isGamePaused() { return GamePaused; }

	// Toggle Pause in the game, and set variables
	// Return New Pause state
	public static bool TogglePause()
	{
		GamePaused = !GamePaused;

		if (GamePaused) {
			Time.timeScale = 0.0f;
		} else {
			Time.timeScale = 1.0f;
		}

		return isGamePaused();
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Responsible for managing all attributes that are maintained throughout all of
 * the levels
 */
public class GameManager : Singleton<GameManager>
{
	private bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
		gamePaused = false;
		Debug.Log("Game Manager initialized");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Spawns 4 Pause Button prefabs on each side of the Gameplay screen.  */

public class SpawnPauseButtons : MonoBehaviour
{
	private Camera cam;
	public GameObject PauseButtonPrefab;
	public float PauseDelay;
	public PauseManager PauseManager;

    // Start is called before the first frame update
    void Start()
    {
		cam = Camera.main;

		// Spawn Buttons on each sides of the screen
		for (int i = 0; i < 2; i++) {
			for (int d = 0; d < 2; d++) {
				GameObject n = Instantiate(PauseButtonPrefab,
						cam.ViewportToWorldPoint(new Vector3(i,d,1)),
						Quaternion.identity);
				// Set a Reference to the PauseManager so the game can be paused
				GameplayPauseScript gps = n.GetComponent<GameplayPauseScript>();
				gps.SetPauseDelay(PauseDelay);
				gps.SetPauseManager(PauseManager);
			}
		}
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for spawning a predefined number of balls when
// loading the play scene.
public class SpawnBalls : MonoBehaviour
{
	public GameObject BallPrefab;	// Prefab of the Ball
	[Tooltip("Initial Number of Spheres (Level 1)")]
	public int InitialSpawnNumber;
	[Tooltip("Maximum number of Spheres to spawn")]
	public int SpawnCap;
	[Tooltip("Initial Velocity of the Spheres (Level 1)")]
	public int BaseVelocity;
	[Tooltip("Rate Scaler for the Velocity of Objects to change each level")]
	public float VelocityScaler;
	private Camera cam;

	// Start is called before the first frame update
	void Start()
	{
		cam = Camera.main;
		spawnObjects();

		if (GameManager.isGamePaused())
			GameManager.TogglePause();
	}

	// Return a random Vector2 that is within 0.05f of the edges of the screen.
	private Vector3 getRandomPoint()
	{
		float x = Random.Range(0.05f, 0.95f);
		float y = Random.Range(0.05f, 0.95f);

		Vector3 pt = new Vector3(x, y, 0);
		return cam.ViewportToWorldPoint(pt);
	}

	/* Spawn a number of Sphere objects based upon the level of the game.
	 * First level will be 4, and increments until Max is reached
	 */
	private void spawnObjects()
	{
	 	int SpawnNumber = InitialSpawnNumber + (GameManager.GetGameLevel() - 1);
		if (SpawnNumber > SpawnCap)
			SpawnNumber = SpawnCap;

		// Change Velocity based upon Game Level and Velocity Scaler
		float MaxBallVelocity = BaseVelocity;
		MaxBallVelocity += GameManager.GetGameLevel() * VelocityScaler;

		// Instantiate SpawnNumber of Ball Prefabs in the Scene
		for (int i = 0; i < SpawnNumber; i++) {
			GameObject c = Instantiate(BallPrefab, getRandomPoint(), Quaternion.identity) as GameObject;
			// Change Object options based upon the level
			var StartScript = c.GetComponent<SphereObject>();
			StartScript.SetMaximumVelocity(MaxBallVelocity);
		}
	}

}

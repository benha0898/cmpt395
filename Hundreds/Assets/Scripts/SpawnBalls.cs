using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for spawning a predefined number of balls when
// loading the play scene.
public class SpawnBalls : MonoBehaviour
{
	public GameObject BallPrefab;	// Prefab of the Ball
	public int SpawnNumber;			// Number of Ball Prefabs to create
	private Camera cam;

	// Start is called before the first frame update
	void Start()
	{
		cam = Camera.main;

		// Instantiate SpawnNumber of Ball Prefabs in the Scene
		for (int i = 0; i < SpawnNumber; i++)
			Instantiate(BallPrefab, randompoint(), Quaternion.identity);
	}

	// Return a random Vector2 that is within 0.05f of the edges of the screen.
	private Vector3 randompoint() {
		float x = Random.Range(0.05f, 0.95f);
		float y = Random.Range(0.05f, 0.95f);

		Vector3 pt = new Vector3(x, y, 0);
		return cam.ViewportToWorldPoint(pt);
	}
}

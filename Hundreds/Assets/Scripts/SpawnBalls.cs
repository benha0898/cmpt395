using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class is responsible for spawning a number of objects in
 *
 * */
public class SpawnBalls : MonoBehaviour
{
	private Camera cam;
	public GameObject BallPrefab;
	public int SpawnNumber;

	// Start is called before the first frame update
	void Start()
	{
		cam = Camera.main;

		for (int i = 0; i < SpawnNumber; i++)
			Instantiate(BallPrefab, randompoint(), Quaternion.identity);
	}

	// Return a random point within the Screen Bounds
	private Vector3 randompoint() {
		float x = Random.Range(0.05f, 0.95f);
		float y = Random.Range(0.05f, 0.95f);

		Vector3 pt= new Vector3(x, y, 0);
		return Camera.main.ViewportToWorldPoint(pt);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* This class is dedicated to handling Mouse Clicks and Multiple Touch Screen
 * touches upon the Balls in a Scene
 */

public class ClickManager : MonoBehaviour
{
	public GameObject TotalPoints;		// Point text associated with object
	public WinLoseManager WLM;
	private float growthRate;
	private int totalPoints;

	// Start is called before the first frame update
	void Start()
	{
		growthRate = Camera.main.orthographicSize * 2 * 1.0f / 100;

		// Initialize Total Points to 0
		TotalPoints.GetComponent<TextMeshPro>().text = "0";
		totalPoints = 0;

	}

	// Update is called once per frame
	void Update()
	{
		// Ignore all Mouse Clicks if the game is paused
		if (GameManager.isGamePaused())
			return;

		// If totalPoints is 100, go to Win Menu
		if (totalPoints == 100)
			WLM.GetWinMenu();

		// Get All Collided gameobjects and apply function based on type
		foreach (GameObject entry in GetInputCollisions())
		{
			if (entry.name == "Sphere(Clone)")
				growSphereObject(entry);
		}
	}

	// Handles both the Mouse and Touch Inputs upon objects, and returns all
	// objects in a HashSet
	HashSet<GameObject> GetInputCollisions()
	{
		// Store all Collisions in a set to prevent duplication
		HashSet<GameObject> FrameCollisions = new HashSet<GameObject>();

		// If there is no Touch points, default to mouse
		for (int i = 0; i < Input.touchCount; i++)
		{
			GameObject collisionObj = getCollidedGameObject(Input.touches[i].position);
			if (collisionObj)
				FrameCollisions.Add(collisionObj);
		}

		// Handle Mouse Input if there is any
		if (Input.GetMouseButton(0)) {
			GameObject collisionObj = getCollidedGameObject(Input.mousePosition);
			if (collisionObj)
				FrameCollisions.Add(collisionObj);
		}

		return FrameCollisions;
	}

	// Get the Game Object that the provided input vector collides with
	GameObject getCollidedGameObject(Vector3 position)
	{
		// Implicit conversion from Vector3 to Vector2
		Vector2 inputPos = Camera.main.ScreenToWorldPoint(position);
		RaycastHit2D hit = Physics2D.Raycast(inputPos, Vector2.zero);

		if (hit.collider)
			return hit.collider.gameObject;

		return null;
	}


	// Grow the Sphere Object
	void growSphereObject(GameObject sphere)
	{
		if (sphere.GetComponent<SphereObject>().collided) {
			Debug.Log("You Lost!");
			WLM.GetLoseMenu();
			return;
		}

		// Only grow an object if it still fits the screen, and if totalpoints < 100
		if ((sphere.transform.localScale[1] < Camera.main.orthographicSize * 2) && (totalPoints < 100))
		{
			// Grow object by increment
			sphere.transform.localScale += new Vector3(growthRate, growthRate, growthRate);

			// Add a point to the ball
			GameObject pointsText = sphere.transform.Find("PointsText(Clone)").gameObject;
			int points = int.Parse(pointsText.GetComponent<TextMeshPro>().text);
			points += 1;
			pointsText.GetComponent<TextMeshPro>().text = points.ToString();

			// Add a point to total points
			totalPoints += 1;
			TotalPoints.GetComponent<TextMeshPro>().text = totalPoints.ToString();
		}
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* This class is dedicated to handling Mouse Clicks and Multiple Touch Screen
 * touches upon the Balls in a Scene
 *
 *
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

		// Handle Growth based upon Mouse Click

		// If totalPoints is 100, go to Win Menu
		if (totalPoints == 100)
		{
			Debug.Log("You Won!");
			WLM.GetWinMenu();
		}

		// If there is no Touch points, default to mouse
		if ( Input.touchCount != 0 ) {
			// Handle growth for Touch Screen touches
			// Note: If touch is 0, then we never enter the loop
			for (int i = 0; i < Input.touchCount; i++)
			{
				Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
				Vector2 touchPos2D = new Vector2(touchPos.x, touchPos.y);

				RaycastHit2D hit = Physics2D.Raycast(touchPos2D, Vector2.zero);

				if (hit.collider != null && hit.collider.gameObject.name == "Sphere(Clone)")
				{
					if (hit.collider.gameObject.GetComponent<SphereObject>().collided)
					{
						Debug.Log("You Lost!");
						WLM.GetLoseMenu();
					}
					else
						growObject(hit);
				}
			}
		} else if (Input.GetMouseButton(0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

			if (hit.collider != null && hit.collider.gameObject.name == "Sphere(Clone)")
			{
				if (hit.collider.gameObject.GetComponent<SphereObject>().collided)
				{
					Debug.Log("You Lost!");
					WLM.GetLoseMenu();
				}
				else
					growObject(hit);
			}
		}

	}

	// Grow the Sphere Object
	void growObject(RaycastHit2D hit)
	{
		// Only grow an object if it still fits the screen, and if totalpoints < 100
		if ((hit.collider.gameObject.transform.localScale[1] < Camera.main.orthographicSize * 2)
				&& (totalPoints < 100))
		{
			// Grow object by increment
			hit.collider.gameObject.transform.localScale += new Vector3(growthRate, growthRate, growthRate);

			// Add a point to the ball
			GameObject pointsText = hit.collider.gameObject.transform.Find("PointsText(Clone)").gameObject;
			int points = int.Parse(pointsText.GetComponent<TextMeshPro>().text);
			points += 1;
			pointsText.GetComponent<TextMeshPro>().text = points.ToString();

			// Add a point to total points
			totalPoints += 1;
			TotalPoints.GetComponent<TextMeshPro>().text = totalPoints.ToString();
		}
	}


}

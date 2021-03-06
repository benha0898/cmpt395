﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereObject : MonoBehaviour
{
	public GameObject PointsPrefab;
	[Tooltip("Maximum Max of the object. 0 to Max.")]
	public float MaxMass;

	public bool collided;

	private float MaxVelocity;
	private Rigidbody2D rb;
	private int point;
	private GameObject points;
	private float minSize;

	// Start is called before the first frame update
	void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();
		collided = false;

		// Randomize Mass
		rb.mass = Random.Range(2.0f, MaxMass);

		// Randomize Velocity
		StartVelocity();

		// Set starting size relative to screen size
		minSize = Camera.main.orthographicSize * 2 / 10; // Starting size = 1/10 screen height
		this.transform.localScale = new Vector3(minSize, minSize, minSize);

		// Display points
		points = Instantiate(PointsPrefab, this.transform.position, Quaternion.identity, this.transform);
		points.transform.localPosition = new Vector3(0f, 0f, -1f);
	}

	public void SetMaximumVelocity(float n)
	{
		this.MaxVelocity = n;
	}

	void StartVelocity()
	{
		float x = Random.Range(-MaxVelocity, MaxVelocity);
		float y = Random.Range(-MaxVelocity, MaxVelocity);

		rb.velocity = new Vector2(x, y);
	}

	// Update is called once per frame
	void Update()
	{
		BounceWall();
	}


	void BounceWall()
	{
		Vector2 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
		Vector3 worldSize = this.transform.localScale;
		float orthoSize = Camera.main.orthographicSize;
		Vector3 screenSize = worldSize*(Screen.height / 2 / orthoSize);
		//Debug.Log(orthoSize + ". screenPos: " + screenPos + ". worldSize: " + worldSize + ". screenSize: " + screenSize);

		if (((screenPos.y + screenSize.y/2) > Screen.height) || ((screenPos.y - screenSize.y/2) < 0f))
		{
			screenPos.y = Mathf.Clamp(screenPos.y, screenSize.y/2, Screen.height - screenSize.y/2);
			Vector2 vel = rb.velocity;
			vel.y = -vel.y;
			rb.velocity = vel;
		}
		if (((screenPos.x + screenSize.x/2) > Screen.width) || ((screenPos.x - screenSize.x/2) < 0f))
		{
			screenPos.x = Mathf.Clamp(screenPos.x, screenSize.x/2, Screen.width - screenSize.x/2);
			Vector2 vel = rb.velocity;
			vel.x = -vel.x;
			rb.velocity = vel;
		}
		Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(screenPos);
		this.transform.position = new Vector2(newWorldPosition.x, newWorldPosition.y);
	}

	private void OnCollisionEnter2D(Collision2D other) {
		collided = true;
	}
	private void OnCollisionExit2D(Collision2D other) {
		collided = false;
	}

}

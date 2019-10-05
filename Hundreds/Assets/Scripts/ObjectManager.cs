using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
	[Tooltip("Maximum Velocity of the object. -Max to Max.")]
	public float MaxVelocity;
	[Tooltip("Maximum Max of the object. 0 to Max.")]
	public float MaxMass;



	private Vector2 screenPos;
	private Vector3 worldSize;
	private Vector3 screenSize;
	private Rigidbody2D rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();

		// Randomize Mass
		rb.mass = Random.Range(2.0f, MaxMass);
		StartVelocity();
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
		screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
		worldSize = this.GetComponent<Renderer>().bounds.size;
		float orthoSize = Camera.main.orthographicSize;
		screenSize = worldSize*(Screen.height / 2 / orthoSize);
		Debug.Log("screenPos: " + screenPos + ". worldSize: " + worldSize + ". screenSize: " + screenSize);

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
}

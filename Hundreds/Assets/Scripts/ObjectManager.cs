using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Vector2 screenPos;
    private Vector3 worldSize;
    private Vector3 screenSize;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        rb.mass = Random.Range(2,6);
        StartVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        BounceWall();
    }

    void StartVelocity()
    {
        int[] dir = new int[] {-1, 1};
        System.Random rand = new System.Random();

        float x = Random.Range(1,4);
        float y = Random.Range(1,4);
        int xDir = dir[rand.Next(dir.Length)];
        int yDir = dir[rand.Next(dir.Length)];

        rb.velocity = new Vector2(x*xDir, y*yDir);
        Debug.Log("x velocity: " + (x*xDir).ToString("F4"));
        Debug.Log("y velocity: " + (y*yDir).ToString("F4"));
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

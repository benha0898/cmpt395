using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{

    public GameObject TotalPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0)){
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("something was clicked!");
                if (hit.collider.gameObject.name == "Sphere(Clone)")
                {
                    Debug.Log(hit.collider.gameObject.name);
                    hit.collider.attachedRigidbody.AddForce(Vector2.up*0);

                    int totalPoints = int.Parse(TotalPoints.GetComponent<TextMeshPro>().text);

                    // Only grow an object if it still fits the screen, and if totalpoints < 100
                    if ((hit.collider.gameObject.transform.localScale[1] < Camera.main.orthographicSize * 2)
                        && (totalPoints < 100))
                    {
                        // Grow object by increment
                        float increment = Camera.main.orthographicSize * 2 * 1.0f / 100;
                        hit.collider.gameObject.transform.localScale += new Vector3(increment, increment, increment);

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
            Debug.Log("Mouse Clicked");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMaster : MonoBehaviour
{
    public float growthRate=0.05f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount!=0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                RaycastHit2D hit = getObject(Camera.main.ScreenToWorldPoint(Input.touches[i].position));
                if (hit.collider != null)
                {
                    hit.collider.gameObject.transform.localScale += new Vector3(growthRate, growthRate, 0);
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = getObject(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (hit.collider != null)
            {
                hit.collider.gameObject.transform.localScale += new Vector3(growthRate, growthRate, 0);
            }
        }
        

    }
    RaycastHit2D getObject(Vector3 screenPos)
    {
        Vector2 screenPos2D = new Vector2(screenPos.x, screenPos.y);

        RaycastHit2D hit = Physics2D.Raycast(screenPos2D, Vector2.zero);
        return hit;
    }
}

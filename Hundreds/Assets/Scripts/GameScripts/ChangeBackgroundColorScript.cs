using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundColorScript : MonoBehaviour
{
	public Color c1, c2, c3, c4, c5, c6;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    // Update is called once per frame
    //Reference: https://docs.unity3d.com/ScriptReference/Camera-backgroundColor.html
    void Update()
    {
        float duration = 14.0F;
		float t = Mathf.PingPong(Time.time, duration) / duration;
        int getLevel = GameManager.GetGameLevel() % 5;

        if (getLevel == 1)
            cam.backgroundColor = Color.Lerp(c1, c2, t);
        else if (getLevel == 2)
            cam.backgroundColor = Color.Lerp(c2, c3, t);
        else if (getLevel == 3)
            cam.backgroundColor = Color.Lerp(c3, c4, t);
        else if (getLevel == 4)
            cam.backgroundColor = Color.Lerp(c4, c5, t);
		else if (getLevel == 5)
            cam.backgroundColor = Color.Lerp(c5, c6, t);
        else
            cam.backgroundColor = Color.Lerp(c6, c1, t);

    }
}

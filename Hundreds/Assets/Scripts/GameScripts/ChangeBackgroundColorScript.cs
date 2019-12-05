using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundColorScript : MonoBehaviour
{
    public Color blue = Color.blue;
    public Color green = Color.green;
    public Color yellow = Color.yellow;
    public Color white = Color.white;
    public Color red = Color.red;
    public Color black = Color.black;

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
            cam.backgroundColor = Color.Lerp(blue, green, t);
        else if (getLevel == 2)
            cam.backgroundColor = Color.Lerp(green, yellow, t);
        else if (getLevel == 3)
            cam.backgroundColor = Color.Lerp(yellow, white, t);
        else if (getLevel == 4)
            cam.backgroundColor = Color.Lerp(white, red, t);
		else if (getLevel == 5)
            cam.backgroundColor = Color.Lerp(red, black, t);
        else
            cam.backgroundColor = Color.Lerp(black, blue, t);

    }
}

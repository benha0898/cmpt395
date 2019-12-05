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

    public Camera cam;


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
        int getLevel;
        float duration = 14.0F;

        getLevel = GameManager.GetGameLevel();

        if (getLevel == 1)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            cam.backgroundColor = Color.Lerp(blue, green, t);
        }

        if (getLevel == 2)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            cam.backgroundColor = Color.Lerp(green, yellow, t);
        }

        if (getLevel == 3)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            cam.backgroundColor = Color.Lerp(yellow, white, t);
        }

        if (getLevel == 4)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            cam.backgroundColor = Color.Lerp(white, red, t);
        }

        if (getLevel == 5)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            cam.backgroundColor = Color.Lerp(red, black, t);
        }

        if (getLevel == 6)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            cam.backgroundColor = Color.Lerp(black, blue, t);
        }

    }
}

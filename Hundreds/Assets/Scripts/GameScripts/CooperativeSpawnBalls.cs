using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for spawning a predefined number of balls when
// loading the play scene.
public class CooperativeSpawnBalls : MonoBehaviour
{
    public GameObject BallPrefab;   // Prefab of the Ball
    [Tooltip("Initial Number of Spheres (Level 1)")]
    public int InitialSpawnNumber;
    [Tooltip("Maximum number of Spheres to spawn")]
    public int SpawnCap;
    [Tooltip("Initial Velocity of the Spheres (Level 1)")]
    public int BaseVelocity;
    [Tooltip("Rate Scaler for the Velocity of Objects to change each level")]
    public float VelocityScaler;
    public int GroupSize;
    [Tooltip("minimum number of balls of the same colour")]
    private Camera cam;
    public Color[] colours;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        if (GameManager.getDifficulty() == "expert")
        {
            InitialSpawnNumber += 3;
            SpawnCap += 6;
            BaseVelocity += 1;
            VelocityScaler += 0.25f;
        }
        spawnObjects();

        if (GameManager.isGamePaused())
            GameManager.TogglePause();

    }

    // Return a random Vector2 that is within 0.05f of the edges of the screen.
    private Vector3 getRandomPoint()
    {
        float x = Random.Range(0.05f, 0.95f);
        float y = Random.Range(0.05f, 0.95f);

        Vector3 pt = new Vector3(x, y, 0);
        return cam.ViewportToWorldPoint(pt);
    }

    /* Spawn a number of Sphere objects based upon the level of the game.
	 * First level will be 4, and increments until Max is reached
	 */
    private void spawnObjects()
    {
        int SpawnNumber = InitialSpawnNumber + (GameManager.GetGameLevel() - 1);
        if (SpawnNumber > SpawnCap)
            SpawnNumber = SpawnCap;

        // Change Velocity based upon Game Level and Velocity Scaler
        float MaxBallVelocity = BaseVelocity;
        MaxBallVelocity += GameManager.GetGameLevel() * VelocityScaler;

        // Instantiate SpawnNumber of Ball Prefabs in the Scene
        for (int i = 0; i < SpawnNumber; i++)
        {
            GameObject c = Instantiate(BallPrefab, getRandomPoint(), Quaternion.identity) as GameObject;
            //c.GetComponent<Renderer>().material.color = new Color(255f, 0,0);
            assignColours(c, i, SpawnNumber);
            // Change Object options based upon the level
            var StartScript = c.GetComponent<SphereObject>();
            StartScript.SetMaximumVelocity(MaxBallVelocity);
        }
    }
    //Assigns colours to the balls as they spawn
    private void assignColours(GameObject ball, int ballNum, int SpawnNumber)
    {
        //Color[] colours = new Color[4]{new Color(255f,0,0),new Color(0,255f,0),new Color(0,0,255f) };
        //Color[] colours = { new Color(255f, 0, 0), new Color(0, 255f, 0), new Color(0, 0, 255f),new Color(255f,255f,255f)};
        if (ballNum >= (SpawnNumber - (SpawnNumber % GroupSize)))
        {
            ball.GetComponent<Renderer>().material.color = colours[ballNum % GroupSize];
        }
        else
        {
            ball.GetComponent<Renderer>().material.color = colours[ballNum / GroupSize];
        }
    }
    //Groups the balls passed to the function into hashsets based upon colours of the balls. Returns an array
    //of the hashsets
    public HashSet<GameObject>[] GroupColours(HashSet<GameObject> balls)
    {
        int i=0;
        HashSet<GameObject>[] colourGroups = new HashSet<GameObject>[colours.Length];
        for (i = 0; i < colours.Length; i++)
        {
            colourGroups[i] = new HashSet<GameObject>();
        }
        foreach (GameObject ball in balls)
        {
            i = 0;
            foreach (Color colour in colours)
            {
                if (ball.GetComponent<Renderer>().material.color == colour)
                {
                    colourGroups[i].Add(ball);
                }
                i++;
            }
        }
        return colourGroups;
    }

}

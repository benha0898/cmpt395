using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    //Called when each ball collides
    void OnCollisionEnter2D(Collision2D col)
    {
        audioSource.Play();
        Debug.Log(col.relativeVelocity[0]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

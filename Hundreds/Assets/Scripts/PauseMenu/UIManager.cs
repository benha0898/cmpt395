using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public PauseManager GM;
    public MusicManager MM;

    public Slider musicSlider;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
 //       musicSlider = GameObject.Find("musicSlider").GetComponent<Slider>();

    }
    // Update is called once per frame
    void Update()
    {
        ScanForKeyStroke();

    }

    void ScanForKeyStroke()
    {
        if (Input.GetKeyDown("escape"))     GM.TogglePauseMenu();

    }

    public void MusicSliderUpdate(float val)
    {
        //Set the volume of the mixer to the value of the slider
        audioMixer.SetFloat("volume", musicSlider.value);
    }
    public void MusicToggle(bool val)
    {
        //Toggles interactibility of the slider and toggles the sound of the mixer on or off
        musicSlider.interactable = musicSlider.interactable ? false : true;
        audioMixer.SetFloat("volume", musicSlider.interactable ? musicSlider.value : -80f);
 
     }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PauseManager GM;
    public MusicManager MM;

    private Slider _musicSlider;
    // Start is called before the first frame update
    void Start()
    {


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
        MM.SetVolume(val);
    }
    public void MusicToggle(bool val)
    {
        _musicSlider.interactable = val;
        MM.SetVolume(val ? _musicSlider.value : 0f);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public AudioSource audio;
    private float musicVolume = 1.0f;
    private Slider slider;
    private GameObject audioOBJ;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        audioOBJ = GameObject.FindGameObjectWithTag("Audio");
        audio = audioOBJ.GetComponent<AudioSource>();
        audio.volume = musicVolume;

    }

    public void SetVolume()
    {
        musicVolume = slider.value;
    }
}

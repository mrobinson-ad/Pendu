using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    [SerializeField]
    AudioSource gameManager;

    [SerializeField]
    AudioSource lose;

    [SerializeField]
    AudioSource win;

    [SerializeField]
    AudioSource[] keys;

    [SerializeField]
    Slider volumeSlider;

    [SerializeField]
    AudioMixer audioMixer;
    

    public void OnMusicChange()
    {
        gameManager.volume = volumeSlider.value;
        lose.volume = volumeSlider.value;
        win.volume = volumeSlider.value;
    }

        public void OnFxChange()
    {
        foreach (AudioSource key in keys)
        {
            key.volume = volumeSlider.value;
        }
    }
}

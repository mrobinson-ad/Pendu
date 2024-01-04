using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void OnVolumeChange()
    {
        gameManager.volume = volumeSlider.value;
        lose.volume = volumeSlider.value;
        win.volume = volumeSlider.value;
        foreach (AudioSource key in keys)
        {
            key.volume = volumeSlider.value*0.4f;
        }
    }
}

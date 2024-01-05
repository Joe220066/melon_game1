using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Voice : MonoBehaviour
{
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 0.5f;
        audio.Play();
    }
    public void OnSliderValueChanged(float slider_value)
    {
        audio.volume = slider_value;
    }
}

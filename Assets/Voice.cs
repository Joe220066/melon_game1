using UnityEngine;

public class Voice : MonoBehaviour
{
    AudioSource audiosource;
    void Start()
    {
        GetComponent<AudioSource>().volume = 0.5f;
        GetComponent<AudioSource>().Play();
    }
    public void OnSliderValueChanged(float slider_value)
    {
        GetComponent<AudioSource>().volume = slider_value;
    }
}

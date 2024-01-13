using UnityEngine;

public class Voice : MonoBehaviour
{
    AudioSource auso;
    void Start()
    {
        auso = GetComponent<AudioSource>();
        auso.volume = 0.5f;
        auso.Play();
    }
    private void Update()
    {
        if (!auso.isPlaying)
        {
            auso.Play();
        }
    }
    public void OnSliderValueChanged(float slider_value)
    {
        auso.volume = slider_value;
    }
}

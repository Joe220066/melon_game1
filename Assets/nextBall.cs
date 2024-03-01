using System;
using UnityEngine;

public class nextBall : MonoBehaviour
{
    readonly float[] size_array = { 0.4f, 0.9f, 1f, 1.3f, 1.8f, 2.2f, 2.5f, 2.9f, 3.2f, 3.4f, 3.7f };
    [SerializeField] Sprite[] img;
    void Resize(int s)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = img[s];
        float size = size_array[s];
        transform.tag = $"ball{s}";
        transform.localScale = new Vector3(size, size, 0f);
    }

    void Start()
    {

    }

    void Update()
    {
        Resize(Player.nextball);
    }
}

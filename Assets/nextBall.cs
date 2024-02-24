using System;
using UnityEngine;

public class nextBall : MonoBehaviour
{
    readonly float[] size_array = { 0.4f, 0.5f, 0.62f, 0.77f, 0.95f, 1.18f, 1.47f, 1.83f, 2.27f, 2.82f, 3.5f };
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

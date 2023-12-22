using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Numerics;
using Unity.VisualScripting;
using System.Drawing;

public class Ball : MonoBehaviour
{
    public float size = 0;
    public GameObject ball;
    float[] size_array = { 0.4f, 0.5f, 0.62f, 0.77f, 0.95f, 1.18f, 1.47f, 1.83f, 2.27f, 2.82f, 3.5f };
    int i = 0;
    void Resize(int s)
    {
        size = size_array[s];
        transform.tag = $"ball{s}";
        transform.localScale = new UnityEngine.Vector3(size, size, 0f);
        i = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (size == 0)
        {
            System.Random ri = new System.Random(Guid.NewGuid().GetHashCode());
            int a = ri.Next(0, 3);
            Resize(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == transform.tag)
        {
            UnityEngine.Vector3 point = coll.gameObject.transform.position;
            UnityEngine.Vector3 pos = GetComponent<Transform>().position;
            pos.x = (point.x + pos.x) / 2;
            pos.y = (point.y + pos.y) / 2;
            pos.z = 0f;
            int s = Int32.Parse(transform.tag[4..]);
            if (s < 11)
            {
                GameObject n = Instantiate(ball, pos, UnityEngine.Quaternion.identity);
                n.name = $"{coll.gameObject.name}{i}";
                i += 1;
                n.SendMessage("Resize", s + 1);
            }
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}

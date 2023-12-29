using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float size = 0;
    [SerializeField] GameObject ball;
    float[] size_array = { 0.4f, 0.5f, 0.62f, 0.77f, 0.95f, 1.18f, 1.47f, 1.83f, 2.27f, 2.82f, 3.5f };
    GameObject pl;
    private static bool ce = true;
    int nextball;
    [SerializeField] Sprite i0;
    [SerializeField] Sprite i1;
    [SerializeField] Sprite i2;
    [SerializeField] Sprite i3;
    [SerializeField] Sprite i4;
    [SerializeField] Sprite i5;
    [SerializeField] Sprite i6;
    [SerializeField] Sprite i7;
    [SerializeField] Sprite i8;
    [SerializeField] Sprite i9;
    [SerializeField] Sprite i10;
    void Resize(int s)
    {
        size = size_array[s];
        transform.tag = $"ball{s}";
        transform.localScale = new UnityEngine.Vector3(size, size, 0f);
        if (s == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = i0;
        }
        else if (s == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = i1;
        }
        else if (s == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = i2;
        }
        else if (s == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = i3;
        }
        else if (s == 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = i4;
        }
        else if (s == 5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = i5;
        }
        else if (s == 6)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = i6;
        }
        else if (s == 7)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = i7;
        }
        else if (s == 8)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = i8;
        }
        else if (s == 9)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = i9;
        }
        else if (s == 10)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = i10;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ce = true;
        if (size == 0)
        {
            System.Random ri = new System.Random(Guid.NewGuid().GetHashCode());
            Resize(nextball);
            nextball = ri.Next(0, 3);
        }
        pl = GameObject.Find("Player");
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
            if (ce)
            {
                UnityEngine.Vector3 point = coll.gameObject.transform.position;
                UnityEngine.Vector3 pos = GetComponent<Transform>().position;
                float x = (point.x + pos.x) / 2;
                float y = (point.y + pos.y) / 2;
                int s = Int32.Parse(transform.tag[4..]);
                Destroy(coll.gameObject);
                if (s < 11)
                {
                    string b = $"{x}/{y}/{s + 1}";
                    pl.SendMessage("NewBall", b);
                }
                ce = false;
                Destroy(gameObject);
            }
        }
        else
        {
            ce = true;
        }
    }
}

using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float size = 0;
    public GameObject ball;
    float[] size_array = { 0.4f, 0.5f, 0.62f, 0.77f, 0.95f, 1.18f, 1.47f, 1.83f, 2.27f, 2.82f, 3.5f };
    GameObject pl;
    private static bool ce = true;
    void Resize(int s)
    {
        size = size_array[s];
        transform.tag = $"ball{s}";
        transform.localScale = new UnityEngine.Vector3(size, size, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        ce = true;
        if (size == 0)
        {
            System.Random ri = new System.Random(Guid.NewGuid().GetHashCode());
            int a = ri.Next(0, 3);
            Resize(a);
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
                Destroy(gameObject);
                ce = false;
            }
        }
        else
        {
            ce = true;
        }
    }
}

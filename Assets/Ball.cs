using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject ball;
    readonly float[] size_array = { 0.4f, 0.5f, 0.62f, 0.77f, 0.95f, 1.18f, 1.47f, 1.83f, 2.27f, 2.82f, 3.5f };
    GameObject pl;
    GameObject text;
    private static bool ce = true;
    static public bool gameover = true;
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
        ce = true;
        pl = GameObject.Find("Player");
        text = GameObject.Find("Text");
    }

    void Update()
    {
        if (GetComponent<Transform>().position.y < -5)
        {
            gameover = false;
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (transform.CompareTag(coll.gameObject.tag) && Ball.gameover)
        {
            if (ce)
            {
                Vector3 point = coll.gameObject.transform.position;
                Vector3 pos = GetComponent<Transform>().position;
                float x = (point.x + pos.x) / 2;
                float y = (point.y + pos.y) / 2;
                int s = Int32.Parse(transform.tag[4..]);
                Destroy(coll.gameObject);
                text.SendMessage("Rescore", s + 1);
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

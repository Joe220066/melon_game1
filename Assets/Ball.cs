using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject ball;
    readonly float[] size_array = { 0.4f, 0.9f, 1f, 1.3f, 1.8f, 2.2f, 2.5f, 2.9f, 3.2f, 3.4f, 3.7f };
    GameObject pl;
    GameObject text;
    private static bool ce = true;
    [SerializeField] Sprite[] img;
    System.Random ri = new System.Random(Guid.NewGuid().GetHashCode());
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
            Player.gamerun = false;
            Destroy(gameObject);
        }
        if (Input.GetKey(KeyCode.DownArrow) && Player.gamerun)
        {
            if (GetComponent<Rigidbody2D>().simulated == false)
            {
                transform.Translate((float)ri.NextDouble() * 0.02f - 0.01f, 0f, 0f);
            }
            GetComponent<Rigidbody2D>().simulated = true;
        }
        if (!GetComponent<Rigidbody2D>().simulated)
        {
            transform.Translate(Player.playerx - GetComponent<Transform>().position[0], 0f, 0f);
        }
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (transform.CompareTag(coll.gameObject.tag) && Player.gamerun)
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

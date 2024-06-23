using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject ball;
    readonly float[] size_array = { 0.4f, 0.9f, 1f, 1.3f, 1.8f, 2.2f, 2.5f, 2.9f, 3.2f, 3.4f, 3.7f };
    GameObject pl, text, control;
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
        pl = GameObject.Find("Player");
        text = GameObject.Find("Text_score");
        control = GameObject.Find("Back_ground");
    }

    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && Game_control.gamerun)
        {
            if (GetComponent<Rigidbody2D>().simulated == false)
            {
                transform.Translate((float)ri.NextDouble() * 0.02f - 0.01f, 0f, 0f);
            }
            GetComponent<Rigidbody2D>().simulated = true;
        }
        if (GetComponent<Transform>().position.y < -5)
        {
            Game_control.gamerun = false;
            control.SendMessage("Gameover");
            Destroy(gameObject);
        }
        if (!GetComponent<Rigidbody2D>().simulated)
        {
            transform.Translate(Player.playerx - GetComponent<Transform>().position[0], 0f, 0f);
        }
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (transform.CompareTag(coll.gameObject.tag))
        {
            coll.gameObject.tag = "ball";
            Vector3 point = coll.gameObject.transform.position;
            Vector3 pos = GetComponent<Transform>().position;
            float x = (point.x + pos.x) / 2;
            float y = (point.y + pos.y) / 2;
            int s = Int32.Parse(transform.tag[4..]);
            Destroy(coll.gameObject);
            text.SendMessage("Scoreadd", s + 1);
            if (s < 11)
            {
                string b = $"{x}/{y}/{s + 1}";
                pl.SendMessage("NewBall", b);
            }
            else
            {
                text.SendMessage("Scoreadd", 89);
            }
            Destroy(gameObject);
        }
    }
}

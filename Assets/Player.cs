using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Instantiate_Position;
    [SerializeField] GameObject ball;
    [SerializeField] float MoveSpeed;
    int n = 0;
    System.Random ri = new System.Random(Guid.NewGuid().GetHashCode());
    static public int nextball;
    static public bool gamerun;
    static public float playerx;
    void Start()
    {
        Vector3 pos = GetComponent<Transform>().position;
        transform.Translate(-4.5f-pos[0], 4f-pos[1], -pos[2]);
        n = 0;
        nextball = ri.Next(0, 3);
        gamerun = true;
        SummonBall();
    }

    void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;
        playerx = pos[0];
        if (Input.GetKey(KeyCode.LeftArrow) && gamerun)
        {
            if (pos[0] > -7)
            {
                transform.Translate(-MoveSpeed*Time.deltaTime,0f,0f);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && gamerun)
        {
            if (pos[0] < -2)
            {
                transform.Translate(MoveSpeed * Time.deltaTime, 0f, 0f);
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && gamerun)
        {
            SummonBall();
        }
    }

    void NewBall(string s)
    {
        string[] str = s.Split("/");
        Vector3 pos;
        pos.x = float.Parse(str[0]);
        pos.y = float.Parse(str[1]);
        pos.z = 0f;
        GameObject t = Instantiate(ball, pos, Quaternion.identity);
        t.name = $"ball{n}";
        n++;
        t.SendMessage("Resize",int.Parse(str[2]));
    }
    void SummonBall()
    {
        Vector3 pl = Instantiate_Position.transform.position;
        pl.x += (float)ri.NextDouble() * 0.02f - 0.01f;
        pl.y -= 0.75f;
        GameObject t = Instantiate(ball, pl, Quaternion.identity);
        t.name = $"ball{n}";
        t.SendMessage("Resize", nextball);
        t.GetComponent<Rigidbody2D>().simulated = false;
        n++;
        nextball = ri.Next(0, 3);
    }
}

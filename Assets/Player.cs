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
    static public float playerx;
    public void Start()
    {
        Vector3 pos = GetComponent<Transform>().position;
        transform.Translate(-4.5f-pos[0], 4f-pos[1], -pos[2]);
    }

    private void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;
        playerx = pos[0];
        if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && Game_control.gamerun)
        {
            SummonBall();
        }
        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Game_control.gamerun)
        {
            if (pos[0] > -7)
            {
                transform.Translate(-MoveSpeed*Time.deltaTime,0f,0f);
            }
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Game_control.gamerun)
        {
            if (pos[0] < -2)
            {
                transform.Translate(MoveSpeed * Time.deltaTime, 0f, 0f);
            }
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
        pl.y -= 0.75f;
        GameObject t = Instantiate(ball, pl, Quaternion.identity);
        t.name = $"ball{n}";
        t.SendMessage("Resize", nextball);
        t.GetComponent<Rigidbody2D>().simulated = false;
        n++;
        nextball = ri.Next(0, 3);
    }
}

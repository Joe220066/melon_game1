using UnityEngine;
using System;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Instantiate_Position;
    [SerializeField] GameObject ball;
    [SerializeField] float MoveSpeed;
    bool i = true;
    int n = 0;
    System.Random ri = new System.Random(Guid.NewGuid().GetHashCode());
    static public int nextball;
    void Start()
    {
        Vector3 pos = GetComponent<Transform>().position;
        transform.Translate(-4.5f-pos[0], 4f-pos[1], -pos[2]);
        n = 0;
        nextball = ri.Next(0, 3);
    }

    void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (pos[0] > -7)
            {
                transform.Translate(-MoveSpeed*Time.deltaTime,0f,0f);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (pos[0] < -2)
            {
                transform.Translate(MoveSpeed * Time.deltaTime, 0f, 0f);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) && i)
        {
            Vector3 pl = Instantiate_Position.transform.position;
            pl.x += (float)ri.NextDouble() * 0.02f - 0.01f;
            GameObject t = Instantiate(ball, pl, Quaternion.identity);
            t.name = $"ball{n}";
            t.SendMessage("Resize", nextball);
            n++;
            nextball = ri.Next(0, 3);
            i = false;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            i = true;
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
}

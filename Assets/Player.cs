using UnityEngine;
using System;
using Unity.Mathematics;

public class Player : MonoBehaviour
{
    public GameObject Instantiate_Position;
    public GameObject ball;
    [SerializeField] float MoveSpeed;
    bool i = true;
    int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = GetComponent<Transform>().position;
        transform.Translate(-4.5f-pos[0], 4f-pos[1], -pos[2]);
        n = 0;
    }

    // Update is called once per frame
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
            System.Random ri = new System.Random(Guid.NewGuid().GetHashCode());
            pl.x += (float)ri.NextDouble() * 0.02f - 0.01f;
            GameObject t = Instantiate(ball, pl, Quaternion.identity);
            t.name = $"ball{n}";
            n++;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject Instantiate_Position;
    public GameObject ball;
    [SerializeField] float MoveSpeed;
    bool i = true;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = GetComponent<Transform>().position;
        transform.Translate(-4.5f-pos[0], 4f-pos[1], -pos[2]);
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
            Instantiate(ball, Instantiate_Position.transform.position, Quaternion.identity);
            i = false;
        }
        if (KeyUpEvent(KeyCode.DownArrow))
        {
            i = true;
        }
    }
}

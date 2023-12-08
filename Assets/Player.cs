using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball
{
    public Ball(float x, float y, int size)
    {

    }
    float[] size_array = { 0.4f, 0.5f, 0.62f, 0.77f, 0.95f, 1.18f, 1.47f, 1.83f, 2.27f, 2.82f, 3.5f };

}
public class Player : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
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
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            
        }
    }
}

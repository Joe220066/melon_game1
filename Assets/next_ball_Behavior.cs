using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_ball_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite[] img;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = img[Player.nextball];
    }
}

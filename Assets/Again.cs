using UnityEngine;

public class Again : MonoBehaviour
{
    private GameObject[] ball;
    GameObject score;
    GameObject button;
    GameObject exit;
    Vector3 pos;
    private void Start()
    {
        score = GameObject.Find("Text");
        button = GameObject.Find("Button");
        exit = GameObject.Find("Exit");
        pos.x = 0f;
        pos.y = 10f;
        pos.z = 0f;
        button.transform.position = pos;
        exit.transform.position = pos;
        gameObject.transform.position = pos;
    }
    private void Update()
    {
        if (!Player.gamerun)
        {
            pos.y = -2f;
            button.transform.position = pos;
            pos.y = -3f;
            exit.transform.position = pos;
            pos.y = 2f;
            gameObject.transform.position = pos;
        }
    }
    public void Main()
    {
        for(int n  = 0; n < 11; n++)
        {
            ball = GameObject.FindGameObjectsWithTag($"ball{n}");
            for(int i = 0; i < ball.Length; i++)
            {
                Destroy(ball[i]);
            }
        }
        Player.gamerun = true;
        score.SendMessage("zero");
        pos.y = 10f;
        button.transform.position = pos;
        exit.transform.position = pos;
        gameObject.transform.position = pos;
    }
}

using System;
using UnityEngine;

public class Game_control: MonoBehaviour
{
    private GameObject[] ball;
    GameObject score, again, exit, gameover, player, backtogame;
    Vector3 pos;
    System.Random ri = new System.Random(Guid.NewGuid().GetHashCode());
    static public int nextball;
    static public bool gamerun;
    private void Start()
    {
        score = GameObject.Find("Text_score");
        again = GameObject.Find("Button_again");
        exit = GameObject.Find("Button_exit");
        gameover = GameObject.Find("gameover");
        player = GameObject.Find("Player");
        backtogame = GameObject.Find("Button_backtogame");
        pos.x = 0f;
        pos.z = 0f;
        Init();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (gamerun)
            {
                Pause();
            }
            else
            {
                Backtogame();
            }
        }
    }

    public void Quitgame()
    {
        Application.Quit();
    }

    public void Again()
    {
        for (int n = 0; n < 11; n++)
        {
            ball = GameObject.FindGameObjectsWithTag($"ball{n}");
            for (int i = 0; i < ball.Length; i++)
            {
                Destroy(ball[i]);
            }
        }
        Init();
    }

    public void Gameover()
    {
        pos.y = -2f;
        again.transform.position = pos;
        pos.y = -3f;
        exit.transform.position = pos;
        pos.y = 2f;
        gameover.transform.position = pos;
    }

    void Init()
    {
        nextball = ri.Next(0, 3);
        gamerun = true;
        pos.y = 10f;
        again.transform.position = pos;
        exit.transform.position = pos;
        gameover.transform.position = pos;
        backtogame.transform.position = pos;
        score.SendMessage("zero");
        player.SendMessage("SummonBall");
    }

    public void Pause()
    {
        gamerun = false;
        pos.y = -2f;
        again.transform.position = pos;
        pos.y = -3f;
        exit.transform.position = pos;
        pos.y = -1f;
        backtogame.transform.position = pos;
    }

    public void Backtogame()
    {
        gamerun = true;
        pos.y = 10f;
        again.transform.position = pos;
        exit.transform.position = pos;
        gameover.transform.position = pos;
        backtogame.transform.position = pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leave_game : MonoBehaviour
{

    public void StartGame ()
    {
        SceneManager.LoadScene("Scene-1");
    }

    public void Quitgame()
    {
        Debug.Log(0);
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}

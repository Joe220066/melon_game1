using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leave_game : MonoBehaviour
{

    public void StartGame ()
    {
        SceneManager.LoadScene("test");
    }

    public void Quitgame()
    {
        Debug.Log(0);
        UnityEditor.EditorApplication.isPlaying = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}

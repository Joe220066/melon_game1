using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leave_game : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    public void StartGame ()
    {
        SceneManager.LoadScene("Scene-1");
    }

    public void Quitgame()
    {
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

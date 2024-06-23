using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_control: MonoBehaviour
{

    public void StartGame ()
    {
        SceneManager.LoadScene("main");
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}

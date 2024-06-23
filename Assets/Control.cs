using UnityEngine;
using UnityEngine.SceneManagement;

public class Control: MonoBehaviour
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

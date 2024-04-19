using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class leave_game : MonoBehaviour
{

    public void StartGame ()
    {
        SceneManager.LoadScene("test");
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}

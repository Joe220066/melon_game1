using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public string targetSceneName = "test";

    // 處理切換場景的函數
    public void SwitchScene()

    {
        // 使用SceneManager.LoadSceneAsync來異步加載場景
        // 如果要同步加載，可以使用LoadScene方法
        SceneManager.LoadSceneAsync(targetSceneName);
    }
}
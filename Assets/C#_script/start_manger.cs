using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_manger : MonoBehaviour
{
    public string targetSceneName = "test";

    // 處理切換場景的函數
    public void SwitchScene()

    {
        // 使用SceneManager.LoadSceneAsync來異步加載場景
        // 如果要同步加載，可以使用LoadScene方法
        SceneManager.LoadSceneAsync(targetSceneName);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SwitchScene();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_manger : MonoBehaviour
{
    public string targetSceneName = "test";

    // �B�z�������������
    public void SwitchScene()

    {
        // �ϥ�SceneManager.LoadSceneAsync�Ӳ��B�[������
        // �p�G�n�P�B�[���A�i�H�ϥ�LoadScene��k
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

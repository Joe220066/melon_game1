using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public string targetSceneName = "test";

    // �B�z�������������
    public void SwitchScene()

    {
        // �ϥ�SceneManager.LoadSceneAsync�Ӳ��B�[������
        // �p�G�n�P�B�[���A�i�H�ϥ�LoadScene��k
        SceneManager.LoadSceneAsync(targetSceneName);
    }
}
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
    GameObject te;
    void Rescore(int s)
    {
        score += s;
    }
    void Start()
    {
        te = GameObject.Find("Text");
        te.GetComponent<TextMeshProUGUI>().text = "分數:";
    }

    void Update()
    {
        te.GetComponent<TextMeshProUGUI>().text = $"分數:{score}";
    }
}

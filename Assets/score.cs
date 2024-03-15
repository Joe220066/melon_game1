using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
    void Rescore(int s)
    {
        score += s;
    }
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "分數:";
    }

    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = $"分數:{score}";
    }
    void zero()
    {
        Debug.Log(0);
        score = 0;
        gameObject.GetComponent<TextMeshProUGUI>().text = $"分數:{score}";
    }
}

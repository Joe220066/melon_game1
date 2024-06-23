using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
    void Scoreadd(int s)
    {
        score += s;
    }
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "分數:0";
    }

    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = $"分數:{score}";
    }
    void zero()
    {
        score = 0;
        gameObject.GetComponent<TextMeshProUGUI>().text = $"分數:0";
    }
}

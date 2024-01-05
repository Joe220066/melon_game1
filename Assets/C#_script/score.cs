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
    // Start is called before the first frame update
    void Start()
    {
        te = GameObject.Find("Text");
        te.GetComponent<TextMeshProUGUI>().text = "score:";
    }

    // Update is called once per frame
    void Update()
    {
        te.GetComponent<TextMeshProUGUI>().text = $"score:{score}";
    }
}

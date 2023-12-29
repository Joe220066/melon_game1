using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text myText;
    public int score_number;

    void Start()
    {
        score_number = 0;
        myText = GetComponent<Text>();
        myText.text = $"{score_number}";
    }

    void Update()
    {
        
    }
}

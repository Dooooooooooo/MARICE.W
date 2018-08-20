using UnityEngine;
using UnityEngine.UI;  

public class ScoreText : MonoBehaviour
{
    public int score = 0;

    void Update()
    {
        this.GetComponent<Text>().text =  score.ToString();
    }
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;  ////ここを追加////

public class ScoreText : MonoBehaviour
{
    public int score = 0;

    void Start()
    {

    }

    void Update()
    {
        this.GetComponent<Text>().text =  score.ToString();
    }
}
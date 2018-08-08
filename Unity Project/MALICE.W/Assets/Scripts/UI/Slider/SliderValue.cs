using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{

    public int score = 0;
    public ScoreText scoreText;

    void Start()
    {
        Slider slider = this.GetComponent<Slider>();
        slider.onValueChanged.AddListener((value) => {
            scoreText.GetComponent<ScoreText>().score = (int)value;
        });
    }
}
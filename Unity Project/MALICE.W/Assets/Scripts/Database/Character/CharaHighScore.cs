using UnityEngine;
using UnityEngine.UI;

public class CharaHighScore : MonoBehaviour
{

    public string text;
    public int Chara_HighScore_num = 0;//今のIDを受け取る

    void Update()
    {
        if (Chara_HighScore_num != 0)
        {
            Character chara = Character.ReadFrom(Chara_HighScore_num);
            this.GetComponent<Text>().text = chara.getHIGHSCORE().ToString();
            Chara_HighScore_num = 0;
        }
    }
}


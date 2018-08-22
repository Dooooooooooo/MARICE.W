using UnityEngine;
using UnityEngine.UI;

public class CharaPlayTime : MonoBehaviour
{

    public string text;
    public int Chara_PlayTime_num = 0;//今のIDを受け取る

    void Update()
    {
        if (Chara_PlayTime_num != 0)
        {
            Character chara = Character.ReadFrom(Chara_PlayTime_num);
            this.GetComponent<Text>().text = chara.getPLAYTIME().ToString();
            Chara_PlayTime_num = 0;
        }
    }
}


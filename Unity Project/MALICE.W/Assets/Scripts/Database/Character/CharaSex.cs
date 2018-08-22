using UnityEngine;
using UnityEngine.UI;
using System.IO;//Fileコマンドにつかう

public class CharaSex : MonoBehaviour
{

    public string text;
    public int Chara_Sex_num = 0;//今のIDを受け取る

    void Update()
    {
        if(Chara_Sex_num != 0)
        {
            Character chara = Character.ReadFrom(Chara_Sex_num);
            this.GetComponent<Text>().text = chara.getSEX();
            Chara_Sex_num = 0;
        }
    }
}


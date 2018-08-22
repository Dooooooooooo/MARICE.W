using UnityEngine;
using UnityEngine.UI;
using System.IO;//Fileコマンドにつかう
using UnityEngine.SceneManagement;

public class CanselButtom : MonoBehaviour {

    public int Cansel_Button_num;

    public void onClick()
    {
        if(Cansel_Button_num != 0) //ここで消去する意味とは...
        {
            Character chara = new Character();

            chara.setID(Cansel_Button_num);
            chara.setNAME("");
            chara.setSEX("");
            chara.setHIGHSCORE(0);
            chara.setPLAYTIME(0);

            chara.WriteToJson();

            Cansel_Button_num = 0;
        }

        SceneManager.LoadScene("Create"); //ほんとうはこれだけにしたい
    }
}

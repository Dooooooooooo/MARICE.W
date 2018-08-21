using UnityEngine;
using UnityEngine.UI;
using System.IO;//Fileコマンドにつかう
using UnityEngine.SceneManagement;

public class CanselButtom : MonoBehaviour {

    public int num;

    public void onClick()
    {
        if(num != 0) //ここで消去する意味とは...
        {
            Character chara = new Character();

            chara.setID(num);
            chara.setNAME("");
            chara.setSEX("");
            chara.setHIGHSCORE(0);
            chara.setPLAYTIME(0);

            chara.WriteToJson();

            num = 0;
        }

        SceneManager.LoadScene("Create"); //ほんとうはこれだけにしたい
    }
}

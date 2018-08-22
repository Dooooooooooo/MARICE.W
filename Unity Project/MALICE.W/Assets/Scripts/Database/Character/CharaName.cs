using UnityEngine;
using UnityEngine.UI;


public class CharaName : MonoBehaviour {

    public string text;
    public int Chara_Name_num = 0;//今のIDを受け取る

	void Update () 
    {
        if(Chara_Name_num != 0)
        {
            Character chara = Character.ReadFrom(Chara_Name_num);
            this.GetComponent<Text>().text = chara.getNAME();
            Chara_Name_num = 0;
        }
	}
}


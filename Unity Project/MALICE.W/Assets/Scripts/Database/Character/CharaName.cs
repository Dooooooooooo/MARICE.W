﻿using UnityEngine;
using UnityEngine.UI;
using System.IO;//Fileコマンドにつかう

public class CharaName : MonoBehaviour {

    public string text;
    public int num = 0;//今のIDを受け取る

	void Update () 
    {
        if(num != 0)
        {
            Character chara = Character.ReadFrom(num);
            this.GetComponent<Text>().text = chara.getNAME();
            num = 0;
        }
	}
}


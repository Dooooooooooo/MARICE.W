﻿using UnityEngine;
using UnityEngine.UI;

public class CharaPlayTime : MonoBehaviour
{

    public string text;
    public int num = 0;//今のIDを受け取る

    void Update()
    {
        if (num != 0)
        {
            Character chara = Character.ReadFrom(num);
            this.GetComponent<Text>().text = chara.getPLAYTIME().ToString();
            num = 0;
        }
    }
}


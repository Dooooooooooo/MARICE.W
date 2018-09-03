using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;  

public class Time : MonoBehaviour {

    private int starttime = 0;
    private int now = 0;
    private int second = 0;
    private int minute = 0;
    private int time = 0;
    private string t_m = ":";
    private string m_s = ":";
    void Start()
    {
        starttime = DateTime.Now.Hour * 60 * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
    }

    void Update()
    {
        if(second >= 60){
            starttime += 60;
            minute++;
        }
        if(minute >= 60){
            minute = 0;
            time++;
        }
        now = DateTime.Now.Hour * 60 * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
        second = now - starttime;

        if(second < 10){
            m_s = ":0";
        }else{
            m_s = ":";
        }
        if(minute < 10){
            t_m = ":0";
        }else{
            t_m = ":0";
        }

        this.GetComponent<Text>().text = time.ToString() + t_m + minute.ToString() + m_s + second.ToString();
    }
}

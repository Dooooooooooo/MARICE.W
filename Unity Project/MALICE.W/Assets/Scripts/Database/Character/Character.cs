using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

//Character（CreateData.csより分離。）

[Serializable]
public class Character
{
  
    [SerializeField] int m_ID;
    [SerializeField] string m_NAME;
    [SerializeField] string m_SEX;
    [SerializeField] int m_HIGHSCORE;
    [SerializeField] int m_PLAYTIME;
      


    public int getID() {
        return m_ID;
    }
    public void setID(int id) {
        this.m_ID = id;
    }

    public string getNAME(){
        return m_NAME;
    }
    public void setNAME(string name){
        this.m_NAME = name;
    }

    public string getSEX(){
        return m_SEX;
    }
    public void setSEX(string sex){
        this.m_SEX = sex;
    }

    public int getHIGHSCORE()
    {
        return m_HIGHSCORE;
    }
    public void setHIGHSCORE(int high_score)
    {
        this.m_HIGHSCORE = high_score;
    }

    public int getPLAYTIME()
    {
        return m_PLAYTIME;
    }
    public void setPLAYTIME(int play_time)
    {
        this.m_PLAYTIME = play_time;
    }
}
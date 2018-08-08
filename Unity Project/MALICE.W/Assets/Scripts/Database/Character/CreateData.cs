using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

//初期宣言
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

public class CreateData : MonoBehaviour
{
    //各種宣言
    public ToggleGroup toggleGroup;
    public InputField NameField;
    Character chara = new Character();

    void Start()
    {
        //名前受けとる
        NameField = GetComponent<InputField>();
    }

    string CreateFilename(int arg)
    {
        return "chara_data_" + arg.ToString() + ".json";
    }

    int flag = 0;//JSONの作成用フラグ
    int score = 0;//スコア初期値
    int time = 0;//タイム初期値



    public void onClick()
    {
        for (int i = 1; i <= 20; i++){
            
            string filename = CreateFilename(i);
            string json_box = File.ReadAllText(Application.dataPath + "/Jsonfiles/" + filename);
            Character json_read_box = new Character();
            json_read_box = JsonUtility.FromJson<Character>(json_box);
            //chara.setID(json_read_box.getID());
            chara.setNAME(json_read_box.getNAME());

            //名前空ならデータなしと判断
            if (chara.getNAME() == "")
            {
                Debug.Log(i + "は良い");

                //InputFieldのデータを受け取る
                Text tex = GameObject.Find("Text").GetComponent<Text>();
                if (tex.text == "")
                {
                    flag = 1;
                    Debug.Log("Please write user name");
                }
                //Toggleのデータを受け取る
                string selectedLabel = toggleGroup.ActiveToggles()
                        .First().GetComponentsInChildren<Text>()
                        .First(t => t.name == "Label").text;
                if (selectedLabel == "")
                {
                    flag = 1;
                    Debug.Log("Please chose user sex");
                }

                //To Json
                if (flag == 0)
                {
                    chara.setID(i);
                    chara.setNAME(tex.text);
                    chara.setSEX(selectedLabel);
                    chara.setHIGHSCORE(score);
                    chara.setPLAYTIME(time);

                    //あとで消す
                    Debug.Log("ID : " + chara.getID());
                    Debug.Log("user : " + chara.getNAME());
                    Debug.Log("sex : " + chara.getSEX());
                    Debug.Log("HighScore : " + chara.getHIGHSCORE());
                    Debug.Log("PlayTime : " + chara.getPLAYTIME());

                    string json = JsonUtility.ToJson(chara);
                    //ここで見えない場所にいるから取得できない？
                    //全部get()で貰いつづければいける？
                    File.WriteAllText(Application.dataPath + "/Jsonfiles/" + filename, json);
                }
            }
        }
    }

}

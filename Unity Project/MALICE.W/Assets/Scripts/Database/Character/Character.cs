using UnityEngine;
using System.IO;
using System;

//Character（CreateData.csより分離。）

[Serializable]
public class Character
{
    public  const int    MAX_FILECOUNT        = 50;
    private const string PATH_TO_DB_JSONFILES = "/Prefabs/Database/Jsonfiles/chara_data_";

    //JSONに書き出されるフィールド
    [SerializeField] int    m_ID;
    [SerializeField] string m_NAME;
    [SerializeField] string m_SEX;
    [SerializeField] int    m_HIGHSCORE;
    [SerializeField] int    m_PLAYTIME;
    

    /* ゲッター・セッター？ */
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

    /* ロード・セーブ処理 */
    public static string FileOf(int arg)
    {
        return Application.dataPath + PATH_TO_DB_JSONFILES + arg.ToString() + ".json";
    }
    public void WriteToJson() {
        File.WriteAllText(FileOf(m_ID), JsonUtility.ToJson(this));
    }

    public static Character ReadFrom(string filepath) {
        string json_box = File.ReadAllText(filepath);
        Character json_read_box = new Character();
        json_read_box = JsonUtility.FromJson<Character>(json_box);
        return json_read_box;
    }

    public static Character ReadFrom(int id) {
        return ReadFrom(FileOf(id));
    }

}
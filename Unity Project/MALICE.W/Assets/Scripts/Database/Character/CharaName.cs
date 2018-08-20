using UnityEngine;
using UnityEngine.UI;
using System.IO;//Fileコマンドにつかう

public class CharaName : MonoBehaviour {

    public string text;
    public int num = 0;//今のIDを受け取る

    //CreateDataからとってきただけだから再利用できたらいいな
    string CreateFilename(int arg)
    {
        return "chara_data_" + arg.ToString() + ".json";
    }

    //これも外からアクセスしたい
    public class Character
    {

        [SerializeField] int m_ID;
        [SerializeField] string m_NAME;
        [SerializeField] string m_SEX;
        [SerializeField] int m_HIGHSCORE;
        [SerializeField] int m_PLAYTIME;



        public int getID()
        {
            return m_ID;
        }
        public void setID(int id)
        {
            this.m_ID = id;
        }

        public string getNAME()
        {
            return m_NAME;
        }
        public void setNAME(string name)
        {
            this.m_NAME = name;
        }

        public string getSEX()
        {
            return m_SEX;
        }
        public void setSEX(string sex)
        {
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
	void Update () 
    {
        if(num != 0)
        {
            Character chara = new Character();
            string filename = CreateFilename(num);
            string json_box = File.ReadAllText(Application.dataPath + "/Prefabs/Database/Jsonfiles/" + filename);
            Character json_read_box = new Character();
            json_read_box = JsonUtility.FromJson<Character>(json_box);
            chara.setNAME(json_read_box.getNAME());
            this.GetComponent<Text>().text = chara.getNAME();
            num = 0;
        }
	}
}


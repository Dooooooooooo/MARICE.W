using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DooPackage.JSONConverter;
using DooPackage.FileReaderWriter;

public class TestManager : MonoBehaviour {
    [SerializeField] JSONConverter m_JSONConverter;
    [SerializeField] FileReaderWriter m_FileReaderWriter;

    private void Start()
    {
        List<PlayerInfo> playerInfos = new List<PlayerInfo>();
        playerInfos.Add(new PlayerInfo(0, "Some", 500));
        playerInfos.Add(new PlayerInfo(1, "Hoge", 400));
        playerInfos.Add(new PlayerInfo(2, "One", 300));




        string json = m_JSONConverter.ConvertToJSON(playerInfos);
        string filepath = Application.dataPath + "/Jsonfiles/Testdata.json";
        //書き込み
        m_FileReaderWriter.Write(new List<string> { json }, filepath);




        //読み込み
        List<string> text = m_FileReaderWriter.Read(filepath);
        string t = text[0];
        List<PlayerInfo> result = m_JSONConverter.ConvertFromJSONToList<PlayerInfo>(t);
        Debug.Log(result[0].name);
    }

    [System.Serializable]
    struct PlayerInfo
    {
        public int id;
        public string name;
        public int score;

        public PlayerInfo(int id, string name, int score)
        {
            this.id = id;
            this.name = name;
            this.score = score;
        }
    }
}

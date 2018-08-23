using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueData : MonoBehaviour
{

    [SerializeField]
    GameObject canvas;
    [SerializeField]
    public GameObject[] Foundation = new GameObject[6];
    [SerializeField]
    public GameObject[] Name = new GameObject[6];
    [SerializeField]
    public GameObject[] HighScore = new GameObject[6];
    [SerializeField]
    public GameObject[] PlayTime = new GameObject[6];
    [SerializeField]
    public CharaName[] charaName = new CharaName[6];
    [SerializeField]
    public CharaHighScore[] charaHighScore = new CharaHighScore[6];
    [SerializeField]
    public CharaPlayTime[] charaPlayTime = new CharaPlayTime[6];

    void Start()
    {
        int n = 0;
        GameObject[] prefab = new GameObject[24];
        for (int i = 1; i <= 10; i++)//ファイル数によって最大値を変更
        {
            Character chara = Character.ReadFrom(i);
            if (chara.getNAME() != "")
            {
                n++;
                if (n <= 6)
                {
                    Debug.Log(n);
                    charaName[n - 1].GetComponent<CharaName>().Chara_Name_num = chara.getID();
                    charaHighScore[n - 1].GetComponent<CharaHighScore>().Chara_HighScore_num = chara.getID();
                    charaPlayTime[n - 1].GetComponent<CharaPlayTime>().Chara_PlayTime_num = chara.getID();
                    prefab[n - 1] = (GameObject)Instantiate(Foundation[n - 1]);
                    prefab[n - 1].transform.SetParent(canvas.transform, false);
                    prefab[n + 5] = (GameObject)Instantiate(Name[n - 1]);
                    prefab[n + 5].transform.SetParent(canvas.transform, false);
                    prefab[n + 11] = (GameObject)Instantiate(HighScore[n - 1]);
                    prefab[n + 11].transform.SetParent(canvas.transform, false);
                    prefab[n + 17] = (GameObject)Instantiate(PlayTime[n - 1]);
                    prefab[n + 17].transform.SetParent(canvas.transform, false);

                }
            }
        }
    }

}

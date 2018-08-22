using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueData : MonoBehaviour {

    [SerializeField]
    GameObject canvas;
    [SerializeField]
    public GameObject Foundation_1;
    [SerializeField]
    public GameObject Foundation_2;
    [SerializeField]
    public GameObject Foundation_3;
    [SerializeField]
    public GameObject Foundation_4;
    [SerializeField]
    public GameObject Foundation_5;
    [SerializeField]
    public GameObject Foundation_6;
    [SerializeField]
    public GameObject Name_1;
    [SerializeField]
    public GameObject Name_2;
    [SerializeField]
    public GameObject Name_3;
    [SerializeField]
    public GameObject Name_4;
    [SerializeField]
    public GameObject Name_5;
    [SerializeField]
    public GameObject Name_6;
    [SerializeField]
    public GameObject HighScore_1;
    [SerializeField]
    public GameObject HighScore_2;
    [SerializeField]
    public GameObject HighScore_3;
    [SerializeField]
    public GameObject HighScore_4;
    [SerializeField]
    public GameObject HighScore_5;
    [SerializeField]
    public GameObject HighScore_6;
    [SerializeField]
    public GameObject PlayTime_1;
    [SerializeField]
    public GameObject PlayTime_2;
    [SerializeField]
    public GameObject PlayTime_3;
    [SerializeField]
    public GameObject PlayTime_4;
    [SerializeField]
    public GameObject PlayTime_5;
    [SerializeField]
    public GameObject PlayTime_6;

    public CharaName charaName_1;
    public CharaName charaName_2;
    public CharaName charaName_3;
    public CharaName charaName_4;
    public CharaName charaName_5;
    public CharaName charaName_6;
    public CharaHighScore charaHighScore_1;
    public CharaHighScore charaHighScore_2;
    public CharaHighScore charaHighScore_3;
    public CharaHighScore charaHighScore_4;
    public CharaHighScore charaHighScore_5;
    public CharaHighScore charaHighScore_6;
    public CharaPlayTime charaPlayTime_1;
    public CharaPlayTime charaPlayTime_2;
    public CharaPlayTime charaPlayTime_3;
    public CharaPlayTime charaPlayTime_4;
    public CharaPlayTime charaPlayTime_5;
    public CharaPlayTime charaPlayTime_6;

	// Use this for initialization
	void Start () {
        int n = 0;
        for (int i = 1; i <= 10;i++){
            Character chara = Character.ReadFrom(i);
            if(chara.getNAME() != ""){
                n++;
                if(n <= 6)
                {
                    switch (n)
                    {
                        case 1:
                            GameObject prefab_22 = (GameObject)Instantiate(Foundation_1);//変数で指定できないか。
                            prefab_22.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_1 = (GameObject)Instantiate(Name_1);//変数で指定できないか。
                            prefab_1.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_7 = (GameObject)Instantiate(HighScore_1);//変数で指定できないか。
                            prefab_7.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_13 = (GameObject)Instantiate(PlayTime_1);//変数で指定できないか。
                            prefab_13.transform.SetParent(canvas.transform, false);//こっちも
                            charaName_1.GetComponent<CharaName>().Chara_Name_num = chara.getID();
                            charaHighScore_1.GetComponent<CharaHighScore>().Chara_HighScore_num = chara.getID();
                            charaPlayTime_1.GetComponent<CharaPlayTime>().Chara_PlayTime_num = chara.getID();
                            break;

                        case 2:
                            GameObject prefab_23 = (GameObject)Instantiate(Foundation_2);//変数で指定できないか。
                            prefab_23.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_2 = (GameObject)Instantiate(Name_2);//変数で指定できないか。
                            prefab_2.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_8 = (GameObject)Instantiate(HighScore_2);//変数で指定できないか。
                            prefab_8.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_14 = (GameObject)Instantiate(PlayTime_2);//変数で指定できないか。
                            prefab_14.transform.SetParent(canvas.transform, false);//こっちも
                            charaName_2.GetComponent<CharaName>().Chara_Name_num = chara.getID();
                            charaHighScore_2.GetComponent<CharaHighScore>().Chara_HighScore_num = chara.getID();
                            charaPlayTime_2.GetComponent<CharaPlayTime>().Chara_PlayTime_num = chara.getID();
                            break;
                        case 3:
                            GameObject prefab_24 = (GameObject)Instantiate(Foundation_3);//変数で指定できないか。
                            prefab_24.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_3 = (GameObject)Instantiate(Name_3);//変数で指定できないか。
                            prefab_3.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_9 = (GameObject)Instantiate(HighScore_3);//変数で指定できないか。
                            prefab_9.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_15 = (GameObject)Instantiate(PlayTime_3);//変数で指定できないか。
                            prefab_15.transform.SetParent(canvas.transform, false);//こっちも
                            charaName_3.GetComponent<CharaName>().Chara_Name_num = chara.getID();
                            charaHighScore_3.GetComponent<CharaHighScore>().Chara_HighScore_num = chara.getID();
                            charaPlayTime_3.GetComponent<CharaPlayTime>().Chara_PlayTime_num = chara.getID();
                            break;
                        case 4:
                            GameObject prefab_25 = (GameObject)Instantiate(Foundation_4);//変数で指定できないか。
                            prefab_25.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_4 = (GameObject)Instantiate(Name_4);//変数で指定できないか。
                            prefab_4.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_10 = (GameObject)Instantiate(HighScore_4);//変数で指定できないか。
                            prefab_10.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_16 = (GameObject)Instantiate(PlayTime_4);//変数で指定できないか。
                            prefab_16.transform.SetParent(canvas.transform, false);//こっちも
                            charaName_4.GetComponent<CharaName>().Chara_Name_num = chara.getID();
                            charaHighScore_4.GetComponent<CharaHighScore>().Chara_HighScore_num = chara.getID();
                            charaPlayTime_4.GetComponent<CharaPlayTime>().Chara_PlayTime_num = chara.getID();
                            break;
                        case 5:
                            GameObject prefab_26 = (GameObject)Instantiate(Foundation_5);//変数で指定できないか。
                            prefab_26.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_5 = (GameObject)Instantiate(Name_5);//変数で指定できないか。
                            prefab_5.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_11 = (GameObject)Instantiate(HighScore_5);//変数で指定できないか。
                            prefab_11.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_17 = (GameObject)Instantiate(PlayTime_5);//変数で指定できないか。
                            prefab_17.transform.SetParent(canvas.transform, false);//こっちも
                            charaName_5.GetComponent<CharaName>().Chara_Name_num = chara.getID();
                            charaHighScore_5.GetComponent<CharaHighScore>().Chara_HighScore_num = chara.getID();
                            charaPlayTime_5.GetComponent<CharaPlayTime>().Chara_PlayTime_num = chara.getID();
                            break;
                        case 6:
                            GameObject prefab_27 = (GameObject)Instantiate(Foundation_6);//変数で指定できないか。
                            prefab_27.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_6 = (GameObject)Instantiate(Name_6);//変数で指定できないか。
                            prefab_6.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_12 = (GameObject)Instantiate(HighScore_6);//変数で指定できないか。
                            prefab_12.transform.SetParent(canvas.transform, false);//こっちも
                            GameObject prefab_18 = (GameObject)Instantiate(PlayTime_6);//変数で指定できないか。
                            prefab_18.transform.SetParent(canvas.transform, false);//こっちも
                            charaName_6.GetComponent<CharaName>().Chara_Name_num = chara.getID();
                            charaHighScore_6.GetComponent<CharaHighScore>().Chara_HighScore_num = chara.getID();
                            charaPlayTime_6.GetComponent<CharaPlayTime>().Chara_PlayTime_num = chara.getID();
                            break;
                    }
                }
            }
        }
	}
	
}

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
    public GameObject[] CharaConfirm = new GameObject[6];
    [SerializeField]
    public GameObject NowPage;
    [SerializeField]
    public GameObject CharaNextPage;
    [SerializeField]
    public GameObject CharaPreviousPage;
    [SerializeField]
    public CharaName[] charaName = new CharaName[6];
    [SerializeField]
    public CharaHighScore[] charaHighScore = new CharaHighScore[6];
    [SerializeField]
    public CharaPlayTime[] charaPlayTime = new CharaPlayTime[6];
    [SerializeField]
    public CharaConfirm[] charaConfirm = new CharaConfirm[6];
    [SerializeField]
    public CharaPageNext charaPageNext;
    [SerializeField]
    public CharaPagePrevious charaPagePrevious;
    [SerializeField]
    public NowPage nowPage;


    public int PageNum = 1;
    public int CharaSum = 0;

    GameObject[] prefab = new GameObject[33];//土台(6)、名前(6)、スコア(6)、時間(6)、キャラ確定ボタン(6)Next(1)、Previous(1)、ページ

    void Start()
    {

        Page page = Page.ReadFrom();
        PageNum = page.getPAGE();

        //PageNum = 2;
        for (int i = 1; i <= 10; i++)//ファイル数によって最大値を変更
        {
            Character chara = Character.ReadFrom(i);
            if (chara.getNAME() != "")
            {
                CharaSum++;
            }
        }

        if(PageNum == 1){
            if (CharaSum <= 6){
                Chara_func();
            }
            else{
                charaPageNext.GetComponent<CharaPageNext>().CharaPageNextNum = PageNum;
                prefab[30] = (GameObject)Instantiate(CharaNextPage);
                prefab[30].transform.SetParent(canvas.transform, false);
                Chara_func();
            }
        }
        else{
            if(CharaSum <= PageNum * 6){
                charaPagePrevious.GetComponent<CharaPagePrevious>().CharaPagePreviousNum = PageNum;
                prefab[31] = (GameObject)Instantiate(CharaPreviousPage);
                prefab[31].transform.SetParent(canvas.transform, false);
                Chara_func();
            }
            else{
                charaPageNext.GetComponent<CharaPageNext>().CharaPageNextNum = PageNum;
                charaPagePrevious.GetComponent<CharaPagePrevious>().CharaPagePreviousNum = PageNum;
                prefab[30] = (GameObject)Instantiate(CharaNextPage);
                prefab[30].transform.SetParent(canvas.transform, false);
                prefab[31] = (GameObject)Instantiate(CharaPreviousPage);
                prefab[31].transform.SetParent(canvas.transform, false);
                Chara_func();
            }
        }
    }

    void Chara_func()
    {
        int n = 0;
        for (int i = 1; i <= 10; i++)//ファイル数によって最大値を変更
        {
            Character chara = Character.ReadFrom(i);
            if (chara.getNAME() != "")
            {
                n++;
                if ( (PageNum - 1) * 6 < n && n <= PageNum * 6)
                {
                    int replace = n - (PageNum - 1) * 6;
                    charaName[replace - 1].GetComponent<CharaName>().num = chara.getID();
                    charaHighScore[replace - 1].GetComponent<CharaHighScore>().num = chara.getID();
                    charaPlayTime[replace - 1].GetComponent<CharaPlayTime>().num = chara.getID();
                    charaConfirm[replace - 1].GetComponent<CharaConfirm>().num = chara.getID();
                    prefab[replace - 1] = (GameObject)Instantiate(Foundation[n - (PageNum - 1) * 6 - 1]);
                    prefab[replace - 1].transform.SetParent(canvas.transform, false);
                    prefab[replace + 5] = (GameObject)Instantiate(Name[n - (PageNum - 1) * 6 - 1]);
                    prefab[replace + 5].transform.SetParent(canvas.transform, false);
                    prefab[replace + 11] = (GameObject)Instantiate(HighScore[n - (PageNum - 1) * 6 - 1]);
                    prefab[replace + 11].transform.SetParent(canvas.transform, false);
                    prefab[replace + 17] = (GameObject)Instantiate(PlayTime[n - (PageNum - 1) * 6 - 1]);
                    prefab[replace + 17].transform.SetParent(canvas.transform, false);
                    prefab[replace + 23] = (GameObject)Instantiate(CharaConfirm[n - (PageNum - 1) * 6 - 1]);
                    prefab[replace + 23].transform.SetParent(canvas.transform, false);

                    nowPage.GetComponent<NowPage>().NowPageNum1 = PageNum;
                    if(CharaSum % 6 == 0){
                        nowPage.GetComponent<NowPage>().NowPageNum2 = CharaSum / 6;
                    }
                    else{
                        nowPage.GetComponent<NowPage>().NowPageNum2 = CharaSum / 6 + 1;
                    }
                    prefab[32] = (GameObject)Instantiate(NowPage);
                    prefab[32].transform.SetParent(canvas.transform, false);

                }
            }
        }
    }


}

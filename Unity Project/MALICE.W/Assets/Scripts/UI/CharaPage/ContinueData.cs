using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MW.UI;

public class ContinueData : MonoBehaviour
{

    [SerializeField]
    GameObject canvas;

    [SerializeField]
    public List<GameObject> Foundation = new List<GameObject>();

    /*[SerializeField]
    public GameObject[] Foundation = new GameObject[6];*/
    //[SerializeField]
    private GameObject[] Name = new GameObject[6];
    private GameObject[] HighScore = new GameObject[6];
    private GameObject[] PlayTime = new GameObject[6];
    private GameObject[] CharaConfirm = new GameObject[6];
    
    [SerializeField] private GameObject NowPage;
    [SerializeField] private GameObject CharaNextPage;
    [SerializeField] private GameObject CharaPreviousPage;

    private CharaName[] charaName = new CharaName[6];
    private CharaHighScore[] charaHighScore = new CharaHighScore[6];
    private CharaPlayTime[] charaPlayTime = new CharaPlayTime[6];
    private CharaConfirm[] charaConfirm = new CharaConfirm[6];

    private CharaPageNext charaPageNext;
    private CharaPagePrevious charaPagePrevious;
    private NowPage nowPage;

    private Action<CharaPager> _pagerUpdated;

    void Start()
    {
        //FoundationオブジェクトからGameObject類を取得する
        for(int i = 0;i < 6; i++) {
            Transform _ft = Foundation[i].transform;

            Name[i]           = _ft.GetChild(0).gameObject;
            HighScore[i]      = _ft.GetChild(1).gameObject;
            PlayTime[i]       = _ft.GetChild(2).gameObject;
            CharaConfirm[i]   = _ft.GetChild(3).gameObject;

            charaName[i]      = Name[i].GetComponent<CharaName>();
            charaHighScore[i] = HighScore[i].GetComponent<CharaHighScore>();
            charaPlayTime[i]  = PlayTime[i].GetComponent<CharaPlayTime>();
            charaConfirm[i]   = CharaConfirm[i].GetComponent<CharaConfirm>();
        }

        charaPageNext     = CharaNextPage.GetComponent<CharaPageNext>();
        charaPagePrevious = CharaPreviousPage.GetComponent<CharaPagePrevious>();
        nowPage           = NowPage.GetComponent<NowPage>();

        //ページャーのインスタンスを取得する
        CharaPager pager = CharaPager.instance;

        //ページを1ページ目にしておく。
        //pager.currentPageNumber = 0;

        //ページャーが更新されたらPagerUpatedが読まれるようにする
        pager.Observe()
             .Attach(PagerUpdated);

        //キャラクターリストを描画
        DrawCharacterList();
    }

    //Destroyされたときに呼ばれるよ
    void OnDestroy() {
        var pager = CharaPager.instance;
        
        //ページャーのイベントリスナーを外すよ
        pager.Observe().Deattach(PagerUpdated);
    }

    void SetVisibilityOfButtons(bool prev, bool next) {
        CharaPreviousPage.SetActive(prev);
        CharaNextPage.SetActive(next);
    }

    void PagerUpdated(CharaPager pager) {
        DrawCharacterList(); //キャラクターリストの再描画
    }

    void DrawCharacterList() {
        //ページャーを取得
        CharaPager pager = CharaPager.instance;

        //現在のページ数を基にページ移動ボタンの状態を指定
        SetVisibilityOfButtons(pager.currentPageNumber != 0,
                               pager.currentPageNumber != (pager.pageCount - 1));

        //ページ数・ページ番号を反映
        var pageIndicator = nowPage.GetComponent<NowPage>();
        pageIndicator.NowPageNum1 = pager.currentPageNumber + 1;
        pageIndicator.NowPageNum2 = pager.pageCount;
        NowPage.SetActive(true);

        //キャラクターリストをリセット
        for(int i = 0; i < 6; i++) {
            Foundation[i].SetActive(false);
            Name[i].SetActive(false);
            HighScore[i].SetActive(false);
            PlayTime[i].SetActive(false);
            CharaConfirm[i].SetActive(false);
        }

        var characters = pager.currentPage;

        for(int i = 0; i < characters.Count; i++) {
            //冗長すぎるデータ書き換え欄...どうにかならぬものか（かえるむ）

            var c = characters[i];

            charaName[i].GetComponent<CharaName>().num           = c.getID();
            charaHighScore[i].GetComponent<CharaHighScore>().num = c.getID();
            charaPlayTime[i].GetComponent<CharaPlayTime>().num   = c.getID();
            charaConfirm[i].GetComponent<CharaConfirm>().num     = c.getID();
            
            Foundation[i].SetActive(true);
            Name[i].SetActive(true);
            HighScore[i].SetActive(true);
            PlayTime[i].SetActive(true);
            CharaConfirm[i].SetActive(true);
        }
    }
}

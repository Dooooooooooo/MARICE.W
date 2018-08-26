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
    private Action<CharaPager> _pagerUpdated;
    void Start()
    {
        //ページャーのインスタンスを取得する
        CharaPager pager = CharaPager.instance;

        //このクラスの_pagerUpdatedを監視する
        pager.Observe()
             .AttachOnce(PagerUpdated);
        
        //現在のページ数を基にページ移動ボタンの状態を指定
        SetVisibilityOfButtons(pager.currentPageNumber != 0,
                               pager.currentPageNumber != (pager.pageCount - 1));

        //キャラクターリストを描画
        DrawCharacterList();
    }

    void SetVisibilityOfButtons(bool prev, bool next) {
        CharaPreviousPage.SetActive(prev);
        CharaNextPage.SetActive(next);
    }

    void PagerUpdated(CharaPager pager) {
        SceneManager.LoadScene("Continue"); //ページをリロード
    }

    void DrawCharacterList() {
        //ページャーを取得
        CharaPager pager = CharaPager.instance;

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
            var c = characters[i];
            charaName[i].GetComponent<CharaName>().num = c.getID();
            charaHighScore[i].GetComponent<CharaHighScore>().num = c.getID();
            charaPlayTime[i].GetComponent<CharaPlayTime>().num = c.getID();
            charaConfirm[i].GetComponent<CharaConfirm>().num = c.getID();

            Foundation[i].SetActive(true);
            Name[i].SetActive(true);
            HighScore[i].SetActive(true);
            PlayTime[i].SetActive(true);
            CharaConfirm[i].SetActive(true);
        }
    }
}

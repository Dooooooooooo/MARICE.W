using UnityEngine;
using UnityEngine.UI;
using System.IO;//Fileコマンドにつかう
using UnityEngine.SceneManagement;

public class CharaPagePrevious : MonoBehaviour
{

    public int CharaPagePreviousNum = 0;

    public void onClick()
    {
        if (CharaPagePreviousNum != 0)
        {
            Page page = Page.ReadFrom();
            int box = page.getPAGE() - 1;
            page.setPage(box);
            page.WriteToJson();
            SceneManager.LoadScene("Continue");
        }

        //ContinueDataのフラグに返したい
    }

}

using UnityEngine;
using UnityEngine.UI;
using System.IO;//Fileコマンドにつかう
using UnityEngine.SceneManagement;

public class CharaPageNext : MonoBehaviour {




    public int CharaPageNextNum = 0;

    public void onClick()
    {
        if(CharaPageNextNum != 0){
            
            Page page = Page.ReadFrom();
            int box = page.getPAGE() + 1;
            page.setPage(box);
            page.WriteToJson();
            SceneManager.LoadScene("Continue");
        }


        //ContinueDataのフラグに返したい
    }

}

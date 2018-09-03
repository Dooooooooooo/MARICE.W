using UnityEngine;
using UnityEngine.UI;
using System.IO;//Fileコマンドにつかう
using UnityEngine.SceneManagement;
using MW.UI;

public class CharaPageNext : MonoBehaviour {




    public int CharaPageNextNum = 0;

    public void onClick()
    {
        CharaPager.Instance.NextPage();
    }

}

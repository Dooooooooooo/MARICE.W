using UnityEngine;
using UnityEngine.UI;
using System.IO;//Fileコマンドにつかう
using UnityEngine.SceneManagement;

using MW.UI;

public class CharaPagePrevious : MonoBehaviour
{

    public int CharaPagePreviousNum = 0;

    public void onClick()
    {
        CharaPager.instance.PrevPage();
    }

}

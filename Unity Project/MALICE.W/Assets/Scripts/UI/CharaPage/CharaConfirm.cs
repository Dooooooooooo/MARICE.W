using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaConfirm : MonoBehaviour
{
    public int num = 0;
    public void OnClick()
    {
        SceneManager.LoadScene("Alternative_game");
    }
}



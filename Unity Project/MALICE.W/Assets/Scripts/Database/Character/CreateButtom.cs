using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateButtom : MonoBehaviour {
    public int Create_Button_num = 0;
    public void OnClick()
    {
        SceneManager.LoadScene("Alternative_game");
    }
}


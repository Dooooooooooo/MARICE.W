using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateButtom : MonoBehaviour {
    public int num = 0;
    public void OnClick()
    {
        SceneManager.LoadScene("Alternative_game");
    }
}


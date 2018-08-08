using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTitle : MonoBehaviour
{

    public void OnClick()
    {
        SceneManager.LoadScene("Title");
    }
}

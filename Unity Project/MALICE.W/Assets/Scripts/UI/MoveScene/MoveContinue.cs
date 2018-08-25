using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveContinue : MonoBehaviour
{

    public void OnClick()
    {
        Page page = Page.ReadFrom();
        page.setPage(1);
        page.WriteToJson();
        SceneManager.LoadScene("Continue");
    }
}

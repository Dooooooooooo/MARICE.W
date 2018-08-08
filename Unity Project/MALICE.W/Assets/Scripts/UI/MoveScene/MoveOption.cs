using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveOption : MonoBehaviour
{

    public void OnClick()
    {
        SceneManager.LoadScene("Option");
    }
}

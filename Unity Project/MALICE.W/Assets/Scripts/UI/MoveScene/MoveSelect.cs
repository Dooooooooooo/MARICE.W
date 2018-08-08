using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSelect : MonoBehaviour
{

    public void OnClick()
    {
        SceneManager.LoadScene("Select");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Elixir : MonoBehaviour
{

    private int starttime = 0;
    private int now = 0;
    private int num = 1;

    void Update()
    {
        if (num != 1)
        {
            this.GetComponent<Text>().text = "0";
            now = DateTime.Now.Hour * 60 * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            if (now - starttime >= 100)
            {
                num = 1;
                starttime = 0;
            }
        }

        else
        {
            this.GetComponent<Text>().text = num.ToString();
            if (Input.GetKeyDown(KeyCode.E))
            {
                starttime = DateTime.Now.Hour * 60 * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
                num = 0;
            }
        }
    }
}

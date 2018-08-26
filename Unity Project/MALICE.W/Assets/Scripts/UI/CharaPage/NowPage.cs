using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

public class NowPage : MonoBehaviour
{

    public string text;
    public int NowPageNum1 = 0;//今のページを受け取る
    public int NowPageNum2 = 0;//総ページ数を受け取る

    void Update()
    {
        if (NowPageNum1 != 0 && NowPageNum2 != 0)
        {
            this.GetComponent<Text>().text = NowPageNum1.ToString() + "/" + NowPageNum2.ToString();
            NowPageNum1 = 0;
            NowPageNum2 = 0;
        }
    }
}






using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

[Serializable]
public class Page
{
    
    private const string PATH_TO_DB_NOW_PAGE = "/Prefabs/Database/NowPage/now_page.json";

    [SerializeField] int m_PAGE;
    public int getPAGE()
    {
        return m_PAGE;
    }
    public void setPage(int page)
    {
        this.m_PAGE = page;
    }

    public static string PageOf()
    {
        return Application.dataPath + PATH_TO_DB_NOW_PAGE;
    }
    public void WriteToJson()
    {
        File.WriteAllText(PageOf(), JsonUtility.ToJson(this));
    }
    public static Page ReadFromPage(string filepath)
    {
        string json_page_box = File.ReadAllText(filepath);
        Page json_read_page_box = new Page();
        json_read_page_box = JsonUtility.FromJson<Page>(json_page_box);
        return json_read_page_box;
    }
    public static Page ReadFrom()
    {
        return ReadFromPage(PageOf());
    }
}
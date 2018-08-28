using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class DataCheck : MonoBehaviour {
    public int flag_get = 0;
    [SerializeField]
    public GameObject select_wall;
    [SerializeField]
    public GameObject name_sex;
    [SerializeField]
    public GameObject name;
    [SerializeField]
    public GameObject sex;
    [SerializeField]
    public GameObject create;
    [SerializeField]
    public GameObject cansel;
    [SerializeField]
    GameObject canvas;
    
    void Update()
    {
        if (flag_get == 3)
        {
            /*
            GameObject prefab   = select_wall; //(GameObject)Instantiate(select_wall);
            GameObject prefab_2 = name_sex;    //(GameObject)Instantiate(name_sex);
            GameObject prefab_3 = name;        //(GameObject)Instantiate(name);
            GameObject prefab_4 = sex;         //(GameObject)Instantiate(sex);
            GameObject prefab_5 = create;      //(GameObject)Instantiate(create);
            GameObject prefab_6 = cansel;      //(GameObject)Instantiate(cansel);

            prefab.transform.SetParent(canvas.transform, false);
            prefab_2.transform.SetParent(canvas.transform, false);
            prefab_3.transform.SetParent(canvas.transform, false);
            prefab_4.transform.SetParent(canvas.transform, false);
            prefab_5.transform.SetParent(canvas.transform, false);
            prefab_6.transform.SetParent(canvas.transform, false);
            */
            List<GameObject> prefabs = new List<GameObject>(){
                (GameObject)select_wall,
                (GameObject)name_sex,
                (GameObject)name,
                (GameObject)sex,
                (GameObject)create,
                (GameObject)cansel
            };
            foreach(var prefab in prefabs) {
                prefab.SetActive(true);
            }
            flag_get = 0;
        }
    }
}

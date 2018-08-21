using UnityEngine;

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
            GameObject prefab = (GameObject)Instantiate(select_wall);
            GameObject prefab_2 = (GameObject)Instantiate(name_sex);
            GameObject prefab_3 = (GameObject)Instantiate(name);
            GameObject prefab_4 = (GameObject)Instantiate(sex);
            GameObject prefab_5 = (GameObject)Instantiate(create);
            GameObject prefab_6 = (GameObject)Instantiate(cansel);
            prefab.transform.SetParent(canvas.transform, false);
            prefab_2.transform.SetParent(canvas.transform, false);
            prefab_3.transform.SetParent(canvas.transform, false);
            prefab_4.transform.SetParent(canvas.transform, false);
            prefab_5.transform.SetParent(canvas.transform, false);
            prefab_6.transform.SetParent(canvas.transform, false);
            flag_get = 0;
        }
    }
}

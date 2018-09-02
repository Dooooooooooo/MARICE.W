using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    public int hp = 100;

    void Update()
    {
        this.GetComponent<Text>().text = hp.ToString();
    }
}
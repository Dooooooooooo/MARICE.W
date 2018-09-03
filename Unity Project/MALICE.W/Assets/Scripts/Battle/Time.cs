using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;  

public class Time : MonoBehaviour {
    private Stopwatch m_Stopwatch = new Stopwatch();
    
    void Start()  => m_Stopwatch.Start();
    void Update() => this.GetComponent<Text>().text = m_Stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
}
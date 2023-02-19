using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text : MonoBehaviour
{
    Text[] _text = new Text[SIZE];
    private Scrollbar scrollbar;
    private const int SIZE = 3;
    private float[] pos = new float[SIZE];
    //private float distance = 0.5f;

    void Start()
    {
        _text[2] = GameObject.Find("Text_Map1").GetComponent<Text>();
        _text[1] = GameObject.Find("Text_Map2").GetComponent<Text>();
        _text[0] = GameObject.Find("Text_Map3").GetComponent<Text>();
        
        pos[0] = 0f;
        pos[1] = 0.5f;
        pos[2] = 1f;
    }

    void Update()
    {
        
        
    }

    
}

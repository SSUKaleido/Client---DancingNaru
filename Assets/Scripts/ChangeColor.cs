using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Scrollbar scrollbar;
    public Camera _camera;
    
    private const int SIZE = 3;
    private float[] pos = new float[SIZE];
    private float distance = 0.5f;

    public Color[] map = { new Color(191, 158, 116), new Color(160, 183, 191), new Color(189, 219, 210) };

    private void Start()
    {
        pos[0] = 0f;
        pos[1] = 0.5f;
        pos[2] = 1f;

        _camera.GetComponent<Camera>();
    }
    
   
    public float duration = 0.2f; // duration in seconds
    public float t = 0; // lerp control variable
    private void FixedUpdate()
    {
        if (scrollbar.value < pos[2] + distance * 0.5f && scrollbar.value > pos[2] - distance * 0.5f) 
        {
            Color Map1Color = _camera.backgroundColor;
            
            _camera.backgroundColor = Color.Lerp(Map1Color, map[2], t);
            
            if (t < 1f)
                t += Time.deltaTime/duration;
        }
        
        if (scrollbar.value < pos[1] + distance * 0.5f && scrollbar.value > pos[1] - distance * 0.5f) 
        {
            Color Map2Color = _camera.backgroundColor;
            if (t < 1f)
                t += Time.deltaTime/duration;
            _camera.backgroundColor = Color.Lerp(Map2Color, map[1], t);
        }

        if (scrollbar.value < pos[0] + distance * 0.5f && scrollbar.value > pos[0] - distance * 0.5f)
        {
            Color Map3Color = _camera.backgroundColor;
            if (t < 1f)
                t += Time.deltaTime/duration;
            _camera.backgroundColor = Color.Lerp(Map3Color, map[0], t);
        }
    }
}

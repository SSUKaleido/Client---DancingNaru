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
    
    private float[] pos = new float[5];
    private float distance = 0.25f;

    public Color[] map =
    {
        new Color(1, 1, 1), new Color(1, 1, 1), new Color(191, 158, 116), new Color(160, 183, 191),
        new Color(189, 219, 210)
    };

    private void Start()
    {
        pos[0] = 0f;
        pos[1] = 0.25f;
        pos[2] = 0.5f;
        pos[3] = 0.75f;
        pos[4] = 1f;

        _camera.GetComponent<Camera>();
        _camera.backgroundColor = map[4];
        
    }

    private void Update()
    {
        if (scrollbar.value < pos[4] + distance * 0.5f && scrollbar.value > pos[4] - distance * 0.5f)
        {
            StartCoroutine(LerpColor(map[4]));
        }
        if (scrollbar.value < pos[3] + distance * 0.5f && scrollbar.value > pos[3] - distance * 0.5f)
        {
            StartCoroutine(LerpColor(map[3]));
        } 
        if (scrollbar.value < pos[2] + distance * 0.5f && scrollbar.value > pos[2] - distance * 0.5f)
        {
            StartCoroutine(LerpColor(map[2]));
        } 
        if (scrollbar.value < pos[1] + distance * 0.5f && scrollbar.value > pos[1] - distance * 0.5f)
        {
            StartCoroutine(LerpColor(map[1]));
        } 
        if (scrollbar.value < pos[0] + distance * 0.5f && scrollbar.value > pos[0] - distance * 0.5f)
        {
            StartCoroutine(LerpColor(map[0]));
        } 
    }
    
    public float duration = 0.4f;
    public float smoothness = 0.007f; 
    IEnumerator LerpColor(Color to)
    {
        Color currentColor = _camera.backgroundColor;
        float progress = 0; 
        float increment = smoothness/duration; 
        while(progress < 1)
        {
            _camera.backgroundColor = Color.Lerp(currentColor, to, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
    }
    

}

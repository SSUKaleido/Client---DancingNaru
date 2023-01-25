using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SizeAnim : MonoBehaviour
{
    public Scrollbar scrollbar;
    private Vector3 originScale;
    private Vector3 firstScale;
    private float[] pos = new float[5];

    void Start()
    {
        originScale = transform.localScale;
        firstScale = originScale * 0.6f;

        if (this.GameObject() != GameObject.Find("Map1")) 
            transform.localScale = firstScale;
        
        pos[0] = 0f;
        pos[1] = 0.25f;
        pos[2] = 0.5f;
        pos[3] = 0.75f;
        pos[4] = 1f;
    }
    
    void Update()
    {
        StartCoroutine(Bigger());
        StartCoroutine(Smaller());
        //StartCoroutine(FadeIn());
    }

    IEnumerator Bigger()
    {
        while (scrollbar.value < 0.75f && scrollbar.value >= 0.5f)
        {
            transform.localScale = firstScale * ((1 / scrollbar.value) * (5f/6f));
            
            yield return null;
        }
    }
    
    
    
    IEnumerator Smaller()
    {
        while (scrollbar.value < 0.5f && scrollbar.value >= 0.25f)
        {
            transform.localScale = originScale * (scrollbar.value+pos[2]);
            yield return null;
        }
    }
}
        
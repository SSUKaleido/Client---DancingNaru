using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class SizeAnim : MonoBehaviour
{
    private const int SIZE = 3;
    private float[] pos = new float[SIZE];
    public Scrollbar scrollbar;

    private Vector3 originScale;
    private Vector3 firstScale;
    private Vector3 localScale = new Vector3(400f, 400f, 400f);
    
    void Start()
    {
        originScale = transform.localScale;
        firstScale = localScale * 0.58f;

        if (this.GameObject() != GameObject.Find("Map1"))
            transform.localScale = firstScale;
        
        pos[0] = 0f;
        pos[1] = 0.5f;
        pos[2] = 1f;
    }

    private void Update()
    {
        StartCoroutine(Bigger());
        StartCoroutine(Smaller());
    }

    IEnumerator Bigger()
    {
        if (this.GameObject() == GameObject.Find("Map2")) //기준
        {
            while (scrollbar.value < pos[2] && scrollbar.value >= pos[1]) // 1~0.5
            {
                transform.localScale = firstScale * (1f / scrollbar.value);
                yield return null;
            }
        }

        if (this.GameObject() == GameObject.Find("Map3"))
        {
            while (scrollbar.value < pos[1] && scrollbar.value >= pos[0]) // 0.5~0
            {
                transform.localScale = firstScale * (1f / (scrollbar.value + 0.5f));
                yield return null;
            }
        }
    }
    
    IEnumerator Smaller()
    {
        if (this.GameObject() == GameObject.Find("Map1")) //기준
        {
            while (scrollbar.value < pos[2] && scrollbar.value >= pos[1]) // 1~0.5
            {
                transform.localScale = originScale * (scrollbar.value / 1f);
                yield return null;
            }
        }
        
        if (this.GameObject() == GameObject.Find("Map2")) 
        {
            while (scrollbar.value < pos[1] && scrollbar.value >= pos[0]) // 0.5~0
            {
                transform.localScale = originScale * ((scrollbar.value+0.5f) / 1f);
                yield return null;
            }
        }
    }
}
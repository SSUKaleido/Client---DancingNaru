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
    private float[] pos = new float[5];
    public Scrollbar scrollbar;

    private Vector3 originScale;
    private Vector3 firstScale;
    private Vector3 localScale = new Vector3(780f, 100f, 600f);
    
    void Start()
    {
        originScale = transform.localScale;
        firstScale = localScale * 0.58f;

        if (this.GameObject() != GameObject.Find("Map1"))
            transform.localScale = firstScale;
        
        pos[0] = 0f;
        pos[1] = 0.25f;
        pos[2] = 0.5f;
        pos[3] = 0.75f;
        pos[4] = 1f;
    }

    private void Update()
    {
        StartCoroutine(Bigger());
        StartCoroutine(Smaller());
    }

    IEnumerator Bigger()
    {
        if (this.GameObject() == GameObject.Find("Map2"))
        {
            while (scrollbar.value < pos[4] && scrollbar.value >= pos[3])
            {
                transform.localScale = firstScale * (pos[3] / (scrollbar.value - pos[1]));
                yield return null;
            }
        }

        if (this.GameObject() == GameObject.Find("Map3")) //기준
        {
            while (scrollbar.value < pos[3] && scrollbar.value >= pos[2])
            {
                transform.localScale = firstScale * (pos[3] / scrollbar.value);
                yield return null;
            }
        }

        if (this.GameObject() == GameObject.Find("Map4"))
        {
            while (scrollbar.value < pos[2] && scrollbar.value >= pos[1])
            {
                transform.localScale = firstScale * (pos[3] / (scrollbar.value + pos[1]));
                yield return null;
            }
        }

        if (this.GameObject() == GameObject.Find("Map5"))
        {
            while (scrollbar.value < pos[1] && scrollbar.value >= pos[0])
            {
                transform.localScale = firstScale * (pos[3] / (scrollbar.value + pos[2]));
                yield return null;
            }
        }
    }



    IEnumerator Smaller()
    {
        if (this.GameObject() == GameObject.Find("Map1"))
        {
            while (scrollbar.value < pos[4] && scrollbar.value >= pos[3])
            {
                transform.localScale = originScale * ((scrollbar.value-pos[1])/pos[3]);
                
                yield return null;
            }
        }
        
        if (this.GameObject() == GameObject.Find("Map2")) // 기준
        {
            while (scrollbar.value < pos[3] && scrollbar.value >= pos[2])
            {
                transform.localScale = originScale * (scrollbar.value/pos[3]);
                
                yield return null;
            }
        }
        
        if (this.GameObject() == GameObject.Find("Map3"))
        {
            while (scrollbar.value < pos[2] && scrollbar.value >= pos[1])
            {
                transform.localScale = originScale * ((scrollbar.value+pos[1])/pos[3]);
                
                yield return null;
            }
        }
        
        if (this.GameObject() == GameObject.Find("Map4"))
        {
            while (scrollbar.value < pos[1] && scrollbar.value >= pos[0])
            {
                transform.localScale = originScale * ((scrollbar.value+pos[2])/pos[3]);
                
                yield return null;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnim : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private const int SIZE = 3;
    private float[] pos = new float[SIZE];
    public Scrollbar scrollbar;
    private Color currentColor;
    public float firstValue = 0.5f;
    
    
    void Start()
    {
        _meshRenderer = transform.GetComponent<MeshRenderer>();
        currentColor = _meshRenderer.material.color;
        
        if (gameObject.transform.parent.parent.name != "stage1")
        {
            currentColor.a = firstValue; 
            _meshRenderer.material.color = currentColor;
        }
        
        pos[0] = 0f;
        pos[1] = 0.5f;
        pos[2] = 1f;
    }
    
    void Update()
    {
        StartCoroutine(FadeUp());
        StartCoroutine(FadeDown());
    }


    IEnumerator FadeUp()
    {
        Color curColor = _meshRenderer.material.color;
        
        if(gameObject.transform.parent.parent.name == "stage2" || gameObject.transform.parent.parent.parent.name == "stage2")
            while (scrollbar.value < 1f && scrollbar.value >= 0.5f)
            {
                curColor.a = firstValue + ((1/scrollbar.value)-1f); //0-1
                if (curColor.a >= 1f)
                    curColor.a = 1f;
                
                _meshRenderer.material.color = curColor;

                yield return null;
            }
        
        if(gameObject.transform.parent.parent.name == "stage3" || gameObject.transform.parent.parent.parent.name == "stage3")
            while (scrollbar.value < 0.5f && scrollbar.value >= 0f)
            {
                curColor.a = firstValue + ((1/(scrollbar.value+0.5f))-1f); 
                if (curColor.a >= 1f)
                    curColor.a = 1f;
                
                _meshRenderer.material.color = curColor;

                yield return null;
            }
    }

    IEnumerator FadeDown()
    {
        Color curColor = _meshRenderer.material.color;

        if(gameObject.transform.parent.parent.name == "stage1" || gameObject.transform.parent.parent.parent.name == "stage1")
            while (scrollbar.value < 1f && scrollbar.value >= 0.5f)
            {
                curColor.a = 1f - ((1/scrollbar.value)-1f);   //0-1
                if (curColor.a <= 0.6f)
                    curColor.a = 0.6f;
                
                _meshRenderer.material.color = curColor;

                yield return null;
            }
            
        
        if(gameObject.transform.parent.parent.name == "stage2" || gameObject.transform.parent.parent.parent.name == "stage2")
            while (scrollbar.value < 0.5f && scrollbar.value >= 0f)
            {
                curColor.a = 1f - ((1/(scrollbar.value+0.5f))-1f); //0.5-0
                if (curColor.a <= 0.6f)
                    curColor.a = 0.6f;
                
                _meshRenderer.material.color = curColor;

                yield return null;
            }
    }
}

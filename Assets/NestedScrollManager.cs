using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;
    
    private const int SIZE = 5;
    private float[] pos = new float[SIZE];
    private float distance;
    void Start()
    {
        // 거리에 따라 0~1인 pos 대입
        distance = 26f;
        //for (int i = 0; i < SIZE; i++) { pos[i] = distance * i; }

        pos[0] = 0.12f;
        pos[1] = 0.38f;
        pos[2] = 0.64f;
        pos[3] = 0.90f;
        pos[4] = 1f;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    void Update()
    {
        
    }
}

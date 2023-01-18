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
        // distance = 1f / (SIZE - 1);
        /*
        distance = 0.182243f;
        pos[0] = 0.7313084f;
        pos[1] = 0.5490654f;
        pos[2] = 0.3668224f;
        pos[3] = 0.1845794f;
        pos[4] = 0.0023364f;
        */
        
        
        
        
        
        
        
        
        
        
        
        
        
        
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

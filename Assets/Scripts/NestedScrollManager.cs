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
    private float distance, targetPos;
    private bool isDrag;
    
    void Start()
    {
        scrollbar.value = 1f; // 초기 화면 설정
        distance = 0.25f; // 맵 중앙 피봇 사이 거리
        // 각 맵이 중앙으로 포커싱 될때 scrollbar value 값
        pos[0] = 0f;
        pos[1] = 0.25f;
        pos[2] = 0.5f;
        pos[3] = 0.75f;
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

        // 움직임 doTween DOmove
        for (int i = 0; i < SIZE; i++)
        {
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f) //현재 value값과 가까운 맵으로 이동 
            {
                scrollbar.value = pos[i];
            }
        }
    }

    void Update()
    {
    }
}

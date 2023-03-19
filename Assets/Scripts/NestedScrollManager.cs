using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NestedScrollManager : MonoBehaviour, IEndDragHandler
{
    public Scrollbar scrollbar;

    private const int SIZE = 3;
    private float[] pos = new float[SIZE];
    private float distance;

    private void Awake()
    {
        scrollbar.value = 1f; // 초기 화면 설정
    }

    void Start()
    {
        distance = 0.5f; // 맵 중앙 피봇 사이 거리
        
        // 각 맵이 중앙으로 포커싱 될때 scrollbar value 값
        pos[0] = 0f;
        pos[1] = 0.5f;
        pos[2] = 1f;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        for (int i = 0; i < SIZE; i++)
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f) 
            {
                StartCoroutine(CoMoveScrollRect(pos[i]));
                break;  
            }
    }
    
    public float moveTime = 1f;
    private float curTime;
    IEnumerator CoMoveScrollRect(float to)
    {
        curTime = 0f;
        float initValue = scrollbar.value;
        
        while (curTime < moveTime) 
        {
            curTime += Time.deltaTime;
            scrollbar.value = Mathf.Lerp(initValue, to, curTime / moveTime);

            yield return null;
        }
    }
}

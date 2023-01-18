using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class NestedScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;
    public ScrollRect scrollRect;
    
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

    public float to;
    public float moveTime = 1f;
    private float curTime;
    public void OnEndDrag(PointerEventData eventData)
    {
        
        for(int i = 0; i < 5; i++)
        if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f) //현재 value값과 가까운 맵으로 이동 
        {
            print(pos[i]);
            StartCoroutine(CoMoveScrollRect(pos[i]));

            break;
            //scrollRect.DOVerticalNormalizedPos(to, 1, true);
        }
    }

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

    void Update()
    {
        print(scrollbar.value);
    }
}

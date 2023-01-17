using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEditor;

using UnityEngine;

[DisallowMultipleComponent]
[ExecuteInEditMode]
public class LineSystem : MonoBehaviour
{
    [Tooltip("게임의 진행 속도입니다. 방향 변환 지점 계산에 사용됩니다.")]
    public float gameSpeed;

    [Tooltip("입력 제한 시간입니다. 길의 넓이를 결정합니다.")]
    public float allowedTouchTime;

    /*[Tooltip("")]
    public GameObject RoadPrefap;*/ // 추후에 방식을 정해서 개발 예정
    
    [Tooltip("원하는 타이밍의 초를 입력하고 Assets/Scenes에서 해당 Scene을 더블클릭하면 방향 변환 지점이 하위 오브젝트로 생성됩니다.")]
    public List<float> timeLine = new List<float>();

    //변환점 리스트
    [HideInInspector]
    public List<Vector3> TurningPoint = new List<Vector3>();

    //길 리스트
    [HideInInspector]
    public List<GameObject> RoadObj = new List<GameObject>();


    Vector3 beforePos; // 이전 터닝포인트 좌표
    float beforeTime; // 이전 타임라인
    int needDataNum; // 불필요한 데이터 갯수
    // Update is called once per frame
    void Awake()
    {
        beforePos = Vector3.zero;
        beforeTime = 0;

        if (CheckPointDataIsntNull()) // 터닝포인트에 Null값이 없는지 체크
        {
            Debug.Log("No Wrong Data");
        }

        if (timeLine.Count < TurningPoint.Count - 1) // 타임라인이 삭제되었을 경우 자동으로 터닝포인트 삭제
        {
            while (TurningPoint.Count - 1 > timeLine.Count)
            {
                TurningPoint.RemoveAt(TurningPoint.Count - 1);
            }
        }

        if (RoadObj.Count > 0 && RoadObj.Count > TurningPoint.Count - 1) // 터닝포인트가 삭제되었을 경우 자동으로 길 삭제
        {
            while (RoadObj.Count > TurningPoint.Count - 1)
            {
                DestroyImmediate(RoadObj[RoadObj.Count - 1]);
                RoadObj.RemoveAt(RoadObj.Count - 1);
            }
        }

        if (TurningPoint.Count == 0) // 시작지점 생성
        {
            TurningPoint.Add(Vector3.zero);
        }

        if (timeLine.Count > (TurningPoint.Count - 1))// 타임라인 리스트의 데이터 갯수가 터닝포인트 리스트의 시작지점을 제외한데이터 개수보다 많을경우 터닝포인트 추가
        {
            needDataNum = timeLine.Count - (TurningPoint.Count - 1);
            for (int i = 0; i < needDataNum; i++)
            {
                TurningPoint.Add(Vector3.zero);
            }
        }

        if (timeLine.Count == TurningPoint.Count - 1) // 터닝포인트 좌표 계산
        {
            beforePos = TurningPoint[0];
            for (int i = 0; i < timeLine.Count; i++)
            {
                if (i % 2 == 0)
                {
                    TurningPoint[i + 1] = beforePos + new Vector3(gameSpeed * (timeLine[i] - beforeTime), 0, 0);
                } else
                {
                    TurningPoint[i + 1] = beforePos + new Vector3(0, 0, gameSpeed * (timeLine[i] - beforeTime));
                }
                beforePos = TurningPoint[i + 1];
                beforeTime = timeLine[i];
            }
        }

        if (RoadObj.Count < TurningPoint.Count - 1) // 터닝포인트가 추가되었을 경우 길 추가
        {
            needDataNum = (TurningPoint.Count - 1) - RoadObj.Count;
            for (int i = 0; i < needDataNum; i++)
            {
                RoadObj.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
            }
        }


        if (RoadObj.Count == TurningPoint.Count - 1) // 길 오브젝트 좌표 및 스케일 계산
        {
            beforePos = TurningPoint[0];
            for (int i = 0; i < RoadObj.Count; i++)
            {
                RoadObj[i].transform.SetParent(this.transform);
                RoadObj[i].transform.position = beforePos + new Vector3((TurningPoint[i+1].x - beforePos.x) / 2, 0, (TurningPoint[i + 1].z - beforePos.z)/2);
                if (i % 2 == 0)
                {
                    RoadObj[i].transform.localScale = new Vector3(TurningPoint[i + 1].x - beforePos.x + (1 * (1 + allowedTouchTime)), 1, 1 * (1 + allowedTouchTime));
                }
                else
                {
                    RoadObj[i].transform.localScale = new Vector3(1 * (1 + allowedTouchTime), 1, TurningPoint[i + 1].z - beforePos.z + (1 * (1 + allowedTouchTime)));
                }
                beforePos = TurningPoint[i + 1];
            }
        }
    }

    bool CheckPointDataIsntNull() // 길 오브젝트 리스트에 값이 제대로 들어있는지 확인
    {
        for (int i = 0; i < RoadObj.Count; i++)
        {
            if (RoadObj[i])
            {
                continue;
            }
            ResetPointData();
            ResetRoadData();// null값이 있을 경우 초기화
            Debug.Log("Wrong Data Is Deleted");
            return false;
        }
        return true;
    }

    void ResetPointData() // 터닝포인트 초기화
    {
        while (TurningPoint.Count > 0)
        {
            TurningPoint.RemoveAt(TurningPoint.Count - 1);
        }
    }

    void ResetRoadData() // 길 초기화
    {
        while (RoadObj.Count > 0)
        {
            DestroyImmediate(RoadObj[RoadObj.Count - 1]);
            RoadObj.RemoveAt(RoadObj.Count - 1);
        }
    }
}

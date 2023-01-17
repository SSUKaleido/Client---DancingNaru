using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEditor;

using UnityEngine;

[DisallowMultipleComponent]
[ExecuteInEditMode]
public class LineSystem : MonoBehaviour
{
    [Tooltip("������ ���� �ӵ��Դϴ�. ���� ��ȯ ���� ��꿡 ���˴ϴ�.")]
    public float gameSpeed;

    [Tooltip("�Է� ���� �ð��Դϴ�. ���� ���̸� �����մϴ�.")]
    public float allowedTouchTime;

    /*[Tooltip("")]
    public GameObject RoadPrefap;*/ // ���Ŀ� ����� ���ؼ� ���� ����
    
    [Tooltip("���ϴ� Ÿ�̹��� �ʸ� �Է��ϰ� Assets/Scenes���� �ش� Scene�� ����Ŭ���ϸ� ���� ��ȯ ������ ���� ������Ʈ�� �����˴ϴ�.")]
    public List<float> timeLine = new List<float>();

    //��ȯ�� ����Ʈ
    [HideInInspector]
    public List<Vector3> TurningPoint = new List<Vector3>();

    //�� ����Ʈ
    [HideInInspector]
    public List<GameObject> RoadObj = new List<GameObject>();


    Vector3 beforePos; // ���� �ʹ�����Ʈ ��ǥ
    float beforeTime; // ���� Ÿ�Ӷ���
    int needDataNum; // ���ʿ��� ������ ����
    // Update is called once per frame
    void Awake()
    {
        beforePos = Vector3.zero;
        beforeTime = 0;

        if (CheckPointDataIsntNull()) // �ʹ�����Ʈ�� Null���� ������ üũ
        {
            Debug.Log("No Wrong Data");
        }

        if (timeLine.Count < TurningPoint.Count - 1) // Ÿ�Ӷ����� �����Ǿ��� ��� �ڵ����� �ʹ�����Ʈ ����
        {
            while (TurningPoint.Count - 1 > timeLine.Count)
            {
                TurningPoint.RemoveAt(TurningPoint.Count - 1);
            }
        }

        if (RoadObj.Count > 0 && RoadObj.Count > TurningPoint.Count - 1) // �ʹ�����Ʈ�� �����Ǿ��� ��� �ڵ����� �� ����
        {
            while (RoadObj.Count > TurningPoint.Count - 1)
            {
                DestroyImmediate(RoadObj[RoadObj.Count - 1]);
                RoadObj.RemoveAt(RoadObj.Count - 1);
            }
        }

        if (TurningPoint.Count == 0) // �������� ����
        {
            TurningPoint.Add(Vector3.zero);
        }

        if (timeLine.Count > (TurningPoint.Count - 1))// Ÿ�Ӷ��� ����Ʈ�� ������ ������ �ʹ�����Ʈ ����Ʈ�� ���������� �����ѵ����� �������� ������� �ʹ�����Ʈ �߰�
        {
            needDataNum = timeLine.Count - (TurningPoint.Count - 1);
            for (int i = 0; i < needDataNum; i++)
            {
                TurningPoint.Add(Vector3.zero);
            }
        }

        if (timeLine.Count == TurningPoint.Count - 1) // �ʹ�����Ʈ ��ǥ ���
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

        if (RoadObj.Count < TurningPoint.Count - 1) // �ʹ�����Ʈ�� �߰��Ǿ��� ��� �� �߰�
        {
            needDataNum = (TurningPoint.Count - 1) - RoadObj.Count;
            for (int i = 0; i < needDataNum; i++)
            {
                RoadObj.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
            }
        }


        if (RoadObj.Count == TurningPoint.Count - 1) // �� ������Ʈ ��ǥ �� ������ ���
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

    bool CheckPointDataIsntNull() // �� ������Ʈ ����Ʈ�� ���� ����� ����ִ��� Ȯ��
    {
        for (int i = 0; i < RoadObj.Count; i++)
        {
            if (RoadObj[i])
            {
                continue;
            }
            ResetPointData();
            ResetRoadData();// null���� ���� ��� �ʱ�ȭ
            Debug.Log("Wrong Data Is Deleted");
            return false;
        }
        return true;
    }

    void ResetPointData() // �ʹ�����Ʈ �ʱ�ȭ
    {
        while (TurningPoint.Count > 0)
        {
            TurningPoint.RemoveAt(TurningPoint.Count - 1);
        }
    }

    void ResetRoadData() // �� �ʱ�ȭ
    {
        while (RoadObj.Count > 0)
        {
            DestroyImmediate(RoadObj[RoadObj.Count - 1]);
            RoadObj.RemoveAt(RoadObj.Count - 1);
        }
    }
}

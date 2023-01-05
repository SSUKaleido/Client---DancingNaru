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
    
    [Tooltip("���ϴ� Ÿ�̹��� �ʸ� �Է��ϰ� Assets/Scenes���� �ش� Scene�� ����Ŭ���ϸ� ���� ��ȯ ������ ���� ������Ʈ�� �����˴ϴ�.")]
    public List<float> timeLine = new List<float>();
    
    //��ȯ�� ����Ʈ
    [HideInInspector]
    public List<GameObject> TurningPoint = new List<GameObject>();


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
                DestroyImmediate(TurningPoint[TurningPoint.Count - 1]);
                TurningPoint.RemoveAt(TurningPoint.Count - 1);
            }
        }

        if (TurningPoint.Count == 0) // �������� ����
        {
            TurningPoint.Add(new GameObject());
            TurningPoint[0].transform.position = Vector3.zero;
            TurningPoint[0].name = "Start Pos";
            TurningPoint[0].transform.SetParent(this.transform);
        }

        if (timeLine.Count > (TurningPoint.Count - 1))// Ÿ�Ӷ��� ����Ʈ�� ������ ������ �ʹ�����Ʈ ����Ʈ�� ���������� �����ѵ����� �������� ������� �ʹ�����Ʈ �߰�
        {
            needDataNum = timeLine.Count - (TurningPoint.Count - 1);
            for (int i = 0; i < needDataNum; i++)
            {
                TurningPoint.Add(new GameObject());
            }
        }

        if (timeLine.Count == TurningPoint.Count - 1) // �ʹ�����Ʈ ��ǥ ���
        {
            for (int i = 0; i < timeLine.Count; i++)
            {
                TurningPoint[i + 1].gameObject.name = timeLine[i].ToString();
                if (i % 2 == 0)
                {
                    TurningPoint[i + 1].transform.position = beforePos + new Vector3(gameSpeed * (timeLine[i] - beforeTime), 0, 0);
                } else
                {
                    TurningPoint[i + 1].transform.position = beforePos + new Vector3(0, 0, gameSpeed * (timeLine[i] - beforeTime));
                }
                TurningPoint[i + 1].transform.SetParent(this.transform);
                beforePos = TurningPoint[i + 1].transform.position;
                beforeTime = timeLine[i];
            }
        }
    }

    bool CheckPointDataIsntNull() // �ʹ�����Ʈ ����Ʈ�� ���� ����� ����ִ��� Ȯ��
    {
        for (int i = 0; i < TurningPoint.Count; i++)
        {
            if (TurningPoint[i])
            {
                continue;
            }
            ResetPointData(); // null���� ���� ��� �ʱ�ȭ
            Debug.Log("Wrong Data Is Deleted");
            return false;
        }
        return true;
    }

    void ResetPointData() // �ʹ�����Ʈ �ʱ�ȭ
    {
        while (TurningPoint.Count > 0)
        {
            DestroyImmediate(TurningPoint[TurningPoint.Count - 1]);
            TurningPoint.RemoveAt(TurningPoint.Count - 1);
        }
    }
}

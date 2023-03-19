using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEditor;

using UnityEngine;

[DisallowMultipleComponent]
[ExecuteInEditMode]
public class LineSystem : MonoBehaviour
{
    [Tooltip("True: Trun on MeshRenderer | False: Turn off MeshRenderer")]
    public bool showRoad = false;

    [Tooltip("Used to calculate the TurningPoint's Position")]
    public float gameSpeed;

    [Tooltip("Used to calculate the width of the road.")]
    public float allowedTouchTime;

    [Tooltip("Put the material")]
    public Material RoadMaterial; // ���Ŀ� ����� ���ؼ� ���� ����

    [Tooltip("Enter the desired timing seconds and double-click the scene in Assets/Scenes to create a TurningPoint as a sub-object.")]
    public List<float> timeLine = new List<float>();

    //��ȯ�� ����Ʈ
    [HideInInspector]
    public List<Vector3> TurningPoint = new List<Vector3>();

    //�� ����Ʈ
    [HideInInspector]
    public List<GameObject> RoadObj = new List<GameObject>();


    Vector3 beforePos; // before turningpoint position
    float beforeTime; // before timeline
    int needDataNum; // needed count of data

    // Update is called once per frame
    void Awake()
    {
        beforePos = new Vector3(transform.position.x, transform.position.y, transform.position.z); //Vector3.zero;
        beforeTime = 0;

        if (CheckPointDataIsntNull()) // Check if there is no null value at the turning point
        {
            Debug.Log("No Wrong Data");
        }

        if (timeLine.Count < TurningPoint.Count - 1) // Automatically delete turning point when timeline is deleted

        {
            while (TurningPoint.Count - 1 > timeLine.Count)
            {
                TurningPoint.RemoveAt(TurningPoint.Count - 1);
            }
        }

        if (RoadObj.Count > 0 && RoadObj.Count > TurningPoint.Count - 1) // Automatically delete road object when turning point is deleted
            {
            while (RoadObj.Count > TurningPoint.Count - 1)
            {
                DestroyImmediate(RoadObj[RoadObj.Count - 1]);
                RoadObj.RemoveAt(RoadObj.Count - 1);
            }
        }

        if (TurningPoint.Count == 0) // Create StartPoint
        {
            TurningPoint.Add(Vector3.zero);
        }

        if (timeLine.Count > (TurningPoint.Count - 1))//If the number of data in the timeline list is greater than the number of data excluding the starting point of the turning point list, add a turning point
        {
            needDataNum = timeLine.Count - (TurningPoint.Count - 1);
            for (int i = 0; i < needDataNum; i++)
            {
                TurningPoint.Add(Vector3.zero);
            }
        }

        if (timeLine.Count == TurningPoint.Count - 1) // Calculate TurningPoint Position
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

        if (RoadObj.Count < TurningPoint.Count - 1) // Add a road when a turning point is added
        {
            needDataNum = (TurningPoint.Count - 1) - RoadObj.Count;
            for (int i = 0; i < needDataNum; i++)
            {
                RoadObj.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
            }
        }


        if (RoadObj.Count == TurningPoint.Count - 1) // Calculate road object position and scale
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
                if (RoadMaterial)
                {
                    RoadObj[i].GetComponent<MeshRenderer>().material = RoadMaterial;
                }
                beforePos = TurningPoint[i + 1];
            }
        }

        
    }

    void Update()
    {
        if (RoadObj.Count > 0) // Road visible system
        {
            if (showRoad == false)
            {
                for (int i = 0; i < RoadObj.Count; i++)
                {
                    RoadObj[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < RoadObj.Count; i++)
                {
                    RoadObj[i].GetComponent<MeshRenderer>().enabled = true;
                }
            }
        }
        
    }

    bool CheckPointDataIsntNull() // Check if the value is properly included in the list of road objects
    {
        for (int i = 0; i < RoadObj.Count; i++)
        {
            if (RoadObj[i]) // Initialize if there is a null value
            {
                continue;
            }
            ResetPointData();
            ResetRoadData();
            Debug.Log("Wrong Data Is Deleted");
            return false;
        }
        return true;
    }

    void ResetPointData() // Turning point reset
    {
        while (TurningPoint.Count > 0)
        {
            TurningPoint.RemoveAt(TurningPoint.Count - 1);
        }
    }

    void ResetRoadData() // Road reset
    {
        while (RoadObj.Count > 0)
        {
            DestroyImmediate(RoadObj[RoadObj.Count - 1]);
            RoadObj.RemoveAt(RoadObj.Count - 1);
        }
    }
}

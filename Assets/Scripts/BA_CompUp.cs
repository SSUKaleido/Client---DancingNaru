using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_CompUp : MonoBehaviour
{
    //오브젝트 올라오는 속도
    public float speed = 2.0f;
    //오브젝트의 지면
    public GameObject Ground;

    private float ground;
    private float targetValue_y;

    // Start is called before the first frame update
    void Start()
    {
        //지면
        ground = Ground.GetComponent<Transform>().position.y + Ground.GetComponent<Transform>().localScale.y / 2;

        //오브젝트가 올라와야하는 y목표위치
        targetValue_y = ground + transform.localScale.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        ComeUp(targetValue_y);
    }

    void ComeUp(float Height)
    {
        if (transform.position.y < targetValue_y)
        {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        }
    }
}

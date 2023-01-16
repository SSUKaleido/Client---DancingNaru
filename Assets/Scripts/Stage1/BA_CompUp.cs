using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_CompUp : BackgroundAnimation
{

    public float speed = 4.0f;  //오브젝트 올라오는 속도
    public GameObject groundObject;   //오브젝트의 지면

    private bool animationOn = false;   // 애니메이션 기능
    private float yPos; // 오브젝트의 Y 위치값
    private float groundYPos;   //지면의 Y위치
    private float targetValue_y;    //오브젝트가 올라와야하는 목표 Y위치

    void Start()
    {
        groundYPos = groundObject.GetComponent<Transform>().position.y + groundObject.GetComponent<Transform>().localScale.y / 2;
        targetValue_y = groundYPos + transform.localScale.y / 2;
    }

    void Update()
    {
        if (animationOn == true)
        {
            yPos = transform.position.y;

            if (yPos < targetValue_y)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }

    // 오브젝트가 속해있는 지면 높이에 맞춰 오브젝트가 올라오는 애니메이션

    public override void TriggerAnimation()
    {
        animationOn = true;
    }
}

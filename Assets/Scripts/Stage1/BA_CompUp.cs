using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_CompUp : BackgroundAnimation
{

    public float speed = 7.5f;  //오브젝트 올라오는 속도
    public GameObject groundObject;   //오브젝트의 지면

    private bool animationOn = false;   // 애니메이션 기능
    private float yPos; // 오브젝트의 Y 위치값
    private float groundYPos;   //지면의 Y위치
    private float targetValue_y;    //오브젝트가 올라와야하는 목표 Y위치

    void Start()
    {
        if (groundObject.GetComponent<BA_UpDown>() == true)
        {
            // 지면 오브젝트가 BA_UpDown에 의해 움직일 때
            groundYPos = groundObject.GetComponent<BA_UpDown>().downYPos + groundObject.GetComponent<Transform>().localScale.y / 2;
        }
        else
        {
            // 지면 오브젝트가 움직이지 않을 때
            groundYPos = groundObject.GetComponent<Transform>().position.y + groundObject.GetComponent<Transform>().localScale.y / 2;
        }

        targetValue_y = groundYPos + transform.localScale.y / 2;
    }

    void Update()
    {
        yPos = transform.position.y;
        
        if (animationOn == true)
        {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BA_FlyAway : BGAnimation
{
    public float turnSpeed = 40.0f; // 오브젝트 회전하는 속도
    public float upSpeed = 4.0f;    // 오브젝트 상승하는 속도

    private bool animationOn = false;   // 애니메이션 기능
    private float yPos; // 오브젝트의 Y 위치값
    private float limitYPos = 15.0f;    // 오브젝트 제거되는 높이

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animationOn = true;
        }
        if (animationOn == true)
        {
            TriggerAnimation();
        }

    }

    // 오브젝트가 회전하면서 날아가는 애니메이션
    public override void TriggerAnimation()
    {
        yPos = transform.position.y;

        transform.Translate(Vector3.up * Time.deltaTime * upSpeed, Space.World);
        transform.Rotate(Vector3.one * turnSpeed * Time.deltaTime);
        
        // 일정 높이에 도달하면 오브젝트 제거
        if (yPos >= limitYPos) 
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_RotateAround : BackgroundAnimation
{
    public float speed = 150.0f; //speed 값이 양수이면 위로, 음수이면 아래로 이동
    public bool animationOn = false; // 숫자3 누르면 애니메이션 작동
    public Vector3 rotationPoint = new Vector3(100, 0, 0);  // 회전 기준점

    private int waitingTime = 1; // 1초마다 끊어서 회전
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (animationOn == true)
        {
            timer = timer + Time.deltaTime;

            if (timer > waitingTime)
            {
                transform.RotateAround(rotationPoint, Vector3.up, speed * Time.deltaTime);
                timer = 0;
            }
        }
    }

    public override void TriggerAnimation()
    {
        animationOn = true;
    }
}
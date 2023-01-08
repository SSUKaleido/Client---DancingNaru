using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_RotateAround : MonoBehaviour
{
    public float speed = 150.0f; //speed 값이 양수이면 위로, 음수이면 아래로 이동
    public bool animationOn = false; // 숫자3 누르면 애니메이션 작동
    private Vector3 rotationPoint = new Vector3(100,0,0);
    
    private int waitingTime = 1; // 1초마다 회전
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (animationOn == false)
            {
                animationOn = true;
            }
            else if (animationOn == true)
            {
                animationOn = false;
            }
        }
        
        if (animationOn == true && timer > waitingTime)
        {
            transform.RotateAround(rotationPoint, Vector3.up , speed * Time.deltaTime);
            timer = 0;
        }
    }
}

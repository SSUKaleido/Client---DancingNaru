using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_DownUp : BackgroundAnimation
{
    public float speed = 5.0f;
    public float upYPos = 0.5f; // 다시 위로 올라갔을 때 Y 위치   
    public float downYPos = -0.2f; // 최소로 아래로 내려왔을 때 Y 위치

    private bool animationOn = false; // 숫자 1 누르면 애니메이션 작동
    private float yPos;
    private bool up = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (animationOn == true)
        {
            yPos = transform.position.y;

            if (yPos < downYPos)
            {
                up = true;
            }

            if (up == false && yPos >= downYPos)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            else if (up == true && yPos <= upYPos)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }

    public override void TriggerAnimation()
    {
        animationOn = true;
    }
}

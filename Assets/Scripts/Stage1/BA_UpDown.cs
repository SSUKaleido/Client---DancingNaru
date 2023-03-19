using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_UpDown : BackgroundAnimation
{
    public float speed = 4.0f;  // 애니메이션 속도
    public float upYPos = 0;    // upYPos까지 올라감  
    public float downYPos = -2.0f;  // downYPos까지 내려옴

    private bool animationOn = false;   // 애니메이션 기능
    private float yPos; // 오브젝트의 Y 위치값
    private bool down = false;   //오브젝트가 upYPos까지 올라갔는지 확인   

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

            if (yPos >= upYPos)
            {
                down = true;
            }

            if (down == true && yPos >= downYPos)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            else if (down == false && yPos < upYPos)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }

    }

    // 오브젝트의 위치가 upYPos까지 올라갔다가 downYPos까지 내려오는 애니메이션
    public override void TriggerAnimation()
    {
        animationOn = true;
    }
}

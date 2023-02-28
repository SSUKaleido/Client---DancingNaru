using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_UpOrDown : BackgroundAnimation
{
    public float speed = 1.0f; //speed 값이 양수이면 위로, 음수이면 아래로 이동
    public float targetYPos;
    private float yPos; // 오브젝트의 Y 위치값
    private bool animationOn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yPos = transform.position.y;

        if (animationOn == true)
        {
            //오브젝트가 올라가는 경우
            if (speed > 0)
            {
                if (yPos <= targetYPos)
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                }
            }
            
            // 오브젝트가 내려가는 경우
            else if (speed < 0)
            {
                if (yPos >= targetYPos)
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                }
            }
        }
    }

    public override void TriggerAnimation()
    {
        animationOn = true;
    }
}

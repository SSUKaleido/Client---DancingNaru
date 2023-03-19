using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_UpOrDown : BackgroundAnimation
{
    public float speed = 1.0f; //speed 값이 양수이면 위로, 음수이면 아래로 이동
    public float targetYPos;
    private float yPos; // 오브젝트의 Z 위치값
    private bool animationOn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (animationOn == true)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetYPos, speed * Time.deltaTime), transform.position.z);
            
            // zPos = transform.position.z;
            // //오브젝트가 올라가는 경우
            // if (speed > 0)
            // {
            //     if (zPos <= targetZPos)
            //     {
            //         transform.Translate(Vector3.up * speed * Time.deltaTime);
            //     }
            // }
            
            // // 오브젝트가 내려가는 경우
            // else if (speed < 0)
            // {
            //     if (zPos >= targetZPos)
            //     {
            //         transform.Translate(Vector3.up * speed * Time.deltaTime);
            //     }
            // }
        }
    }

    public override void TriggerAnimation()
    {
        animationOn = true;
    }
}

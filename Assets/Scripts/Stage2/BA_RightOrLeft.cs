using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_RightOrLeft : BackgroundAnimation
{
    public float speed = 1.0f; //speed 값이 양수이면 왼쪽으로, 음수이면 오른쪽로 이동
    public float targetZPos;
    private float zPos; // 오브젝트의 Y 위치값
    private bool animationOn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        zPos = transform.position.z;

        if (animationOn == true)
        {
            //오브젝트가 왼쪽으로 이동하는 경우
            if (speed < 0)
            {
                if (zPos <= targetZPos)
                {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                }
            }
            
            // 오브젝트가 오른쪽으로 이동하는 경우
            else if (speed > 0)
            {
                if (zPos >= targetZPos)
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

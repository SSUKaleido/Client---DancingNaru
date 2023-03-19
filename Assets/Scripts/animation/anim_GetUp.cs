using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_GetUp : BackgroundAnimation
{
    public float speed = 150.0f; //speed 값이 양수이면 위로, 음수이면 아래로 이동
    public Vector3 rotationPoint = new Vector3(100, 0, 0);

    private float upValue = 0;
    public float downValue;
    private bool animationOn = false;

    private bool back = false;
    public float zRotation;

    // Start is called before the first frame update
    void Start()
    {
        downValue = transform.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        zRotation = transform.rotation.z;

        if (animationOn == true)
        {
            // zRotation이 양수인 경우
            if (downValue > 0)
            {
                if (zRotation <= upValue)
                {
                    back = true;
                }

                if (back == false && zRotation >= upValue)
                {
                    transform.RotateAround(rotationPoint, Vector3.left, speed * Time.deltaTime);
                }
                else if (back == true & zRotation <= downValue)
                {
                    transform.RotateAround(rotationPoint, Vector3.right, speed * Time.deltaTime);
                }
            }

            // zRotation이 양수인 경우
            if (downValue < 0)
            {
                if (zRotation >= upValue)
                {
                    back = true;
                }

                if (back == false && zRotation <= upValue)
                {
                    transform.RotateAround(rotationPoint, Vector3.right, speed * Time.deltaTime);
                }
                else if (back == true & zRotation >= downValue)
                {
                    transform.RotateAround(rotationPoint, Vector3.left, speed * Time.deltaTime);
                }
            }

            // if (back == false && zRotation <= maxZ)
            // {
            //     transform.RotateAround(rotationPoint, Vector3.right, speed * Time.deltaTime);
            // }
            // else if (back == true && zRotation >= minZ)
            // {
            //     transform.RotateAround(rotationPoint, Vector3.left, speed * Time.deltaTime);
            // }
        }
    }

    public override void TriggerAnimation()
    {
        animationOn = true;
    }
}

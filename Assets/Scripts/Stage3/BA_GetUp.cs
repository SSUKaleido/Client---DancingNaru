using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_GetUp : MonoBehaviour
{
    public float speed = 150.0f; //speed 값이 양수이면 위로, 음수이면 아래로 이동
    public bool animationOn = false; // 숫자3 누르면 애니메이션 작동
    public Vector3 rotationPoint = new Vector3(100, 0, 0);
    public bool back = false;
    public float Z;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Z = transform.rotation.z;
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

        if (animationOn == true)
        {
            if (transform.rotation.z >= 0)
            {
                back = true;
            }
            else if (transform.rotation.z <= -0.7)
            {
                animationOn = false;
                back = false;
            }

            if (back == false && transform.rotation.z <= 0)
            {
                transform.RotateAround(rotationPoint, Vector3.forward, speed * Time.deltaTime);
            }
            else if (back == true &&  transform.rotation.z > -0.7)
            {
                transform.RotateAround(rotationPoint, Vector3.back, speed * Time.deltaTime);
            }
        }

    }
}

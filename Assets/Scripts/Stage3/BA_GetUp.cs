using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_GetUp : MonoBehaviour
{
    public float speed = 150.0f; //speed 값이 양수이면 위로, 음수이면 아래로 이동

    private float maxZ = 0;
    private float minZ = -0.73f;
    private bool animationOn = false; // 숫자3 누르면 애니메이션 작동
    private Vector3 rotationPoint = new Vector3(100, 0, 0);
    private bool back = false;
    private float zRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
            GetUp();
        }
    }
    void GetUp()
    {
        zRotation = transform.rotation.z;

        if (zRotation >= maxZ)
        {
            back = true;
        }
        else if (zRotation <= minZ)
        {
            animationOn = false;
            back = false;
        }

        if (back == false && zRotation <= maxZ)
        {
            transform.RotateAround(rotationPoint, Vector3.forward, speed * Time.deltaTime);
        }
        else if (back == true && zRotation > minZ)
        {
            transform.RotateAround(rotationPoint, Vector3.back, speed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_SetPosition : MonoBehaviour
{
    public float speed = 10;
    public bool animationOn = false; // 숫자4 누르면 애니메이션 작동
    public Vector3 targetPos;   // 오브젝트가 이동할 목표 위치

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;

        if (Input.GetKeyDown(KeyCode.Alpha4))
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
            transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
        }

    }
}

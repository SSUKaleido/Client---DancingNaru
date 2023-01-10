using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_SetPosition : MonoBehaviour
{
    public float speed = 10;
    public Vector3 targetPos;   // 오브젝트가 이동할 목표 위치

    private bool animationOn = false; // 숫자 4 누르면 애니메이션 작동

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animationOn = true;
        }

        if (animationOn == true)
        {
            SetPosition();
        }
    }

    void SetPosition()
    {
        Vector3 currentPos = transform.position;
        transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
    }
}

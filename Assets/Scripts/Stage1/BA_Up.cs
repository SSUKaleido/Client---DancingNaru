using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_Up : MonoBehaviour
{
    public float speed = 4.0f;
    public float upYPos;

    private bool animationOn = false;
    private float yPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //숫자 4 누르면 애니메이션 작동
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animationOn = true;
        }
        if (animationOn == true)
        {
            Up();
        }
    }
    // 원하는 위치까지 올라가는 애니메이션
    void Up() 
    {
        yPos = transform.position.y;

        if (yPos <= upYPos)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_Up : MonoBehaviour
{
    public float speed = 4.0f;
    private bool animationOn = false;
    private float yPos;
    public float upYPos;
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

    void Up() 
    {
        yPos = transform.position.y;

        if (yPos <= upYPos)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}

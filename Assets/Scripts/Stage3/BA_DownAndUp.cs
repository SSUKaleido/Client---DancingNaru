using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_DownAndUp : MonoBehaviour
{
    public float speed = 5.0f; 
    public bool animationOn = false; // 숫자 1 누르면 애니메이션 작동

    public float upYPos = 0.5f; // 다시 위로 올라갔을 때 Y 위치   
    public float downYPos = -0.2f; // 최소로 아래로 내려왔을 때 Y 위치
    public bool up = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
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
            if (transform.position.y < downYPos)
            {
                up = true;
            }

            if (up == false && transform.position.y >= downYPos)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            else if (up == true && transform.position.y <= upYPos)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_Shake : MonoBehaviour
{
    public float speed = 10.0f;

    private bool animationOn = false; // 숫자 2 누르면 애니메이션 작동
    private Vector3 initialPos;


    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
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
            Shake();
        }
    }

    void Shake()
    {
        Vector3 currentPos = initialPos;

        currentPos.x += 0.5f * Mathf.Sin(Time.time * speed);
        transform.position = currentPos;
    }
}

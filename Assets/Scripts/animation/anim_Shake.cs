using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_Shake : BackgroundAnimation
{
    public float speed = 10.0f;

    private bool animationOn = false; // ���� 2 ������ �ִϸ��̼� �۵�
    private Vector3 initialPos;


    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (animationOn == true)
        {
            Vector3 currentPos = initialPos;

            currentPos.x += 0.5f * Mathf.Sin(Time.time * speed);
            transform.position = currentPos;
        }
    }

    public override void TriggerAnimation()
    {
        animationOn = true;
    }
}

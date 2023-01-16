using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_Up : BackgroundAnimation
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
        if (animationOn == true)
        {
            yPos = transform.position.y;

            if (yPos <= upYPos)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }
    // 원하는 위치까지 올라가는 애니메이션
    public override void TriggerAnimation()
    {
        animationOn = true;
    }
}

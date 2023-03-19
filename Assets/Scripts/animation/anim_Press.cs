using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_Press : BackgroundAnimation
{
    public float speed = 5.0f;
    public float upYPos = 0.5f; // �ٽ� ���� �ö��� �� Y ��ġ   
    public float downYPos = -0.2f; // �ּҷ� �Ʒ��� �������� �� Y ��ġ

    private bool animationOn = false; // ���� 1 ������ �ִϸ��̼� �۵�
    private float yPos;
    private bool up = false;

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

            if (yPos < downYPos)
            {
                up = true;
            }

            if (up == false && yPos >= downYPos)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            else if (up == true && yPos <= upYPos)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }

    public override void TriggerAnimation()
    {
        animationOn = true;
    }
}

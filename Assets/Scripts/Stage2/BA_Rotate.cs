using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_Rotate : BackgroundAnimation
{
    public float speed = 10.0f; //speed 값이 양수이면 오른쪽으로, 음수이면 왼쪽으로 이동
    public bool animationOn = false; // 숫자2 누르면 애니메이션 작동
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animationOn == true)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }

    public override void TriggerAnimation() 
    {
        animationOn = true;
    }
}

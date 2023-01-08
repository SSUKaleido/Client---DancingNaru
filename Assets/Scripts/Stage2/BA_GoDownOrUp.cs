using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_GoDownOrUp : MonoBehaviour
{
    public float speed = 1.0f; //speed 값이 양수이면 위로, 음수이면 아래로 이동
    public bool animationOn = false; //숫자1 누르면 애니메이션 작동

    // Start is called before the first frame update
    void Start()
    {

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
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        }
    }
}

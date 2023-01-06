using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_UpDown : MonoBehaviour
{
    private GameObject mainRoad;
    public float speed = 4.0f;

    public float upYPos = 0; //최대로 위로 올라갔을 때 Y 위치   
    public float downYPos = -2.0f; // 다시 내려왔을 때 Y 위치
    public bool down = false;

    // Start is called before the first frame update
    void Start()
    {
        mainRoad = GameObject.Find("MainRoad_UpDown");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= upYPos)
        {
            down = true;
        }

        if (down == true && transform.position.y >= downYPos)
        {
            transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
        }

        else if (down == false && transform.position.y < upYPos)
        {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        }


    }
}

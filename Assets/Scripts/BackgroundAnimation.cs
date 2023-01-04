using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    public float turnSpeed = 40.0f;
    public float upSpeed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlyAway();
    }
    void FlyAway()
    {
        transform.Translate(Vector3.up * Time.deltaTime * upSpeed, Space.World);
        transform.Rotate(new Vector3(turnSpeed, turnSpeed, turnSpeed) * Time.deltaTime);
    }
}

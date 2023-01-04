using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    float x, y, z;
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
        // transform.Translate(new Vector3(0,1,0) * upSpeed *  Time.deltaTime);

        transform.Rotate(new Vector3(5,5,5) * Time.deltaTime);
        
        // x += 50 * Time.deltaTime;
        // y += 50 * Time.deltaTime;
        // z += 50 * Time.deltaTime;

        
        // transform.eulerAngles = new Vector3(x, 0, 0);
    }
}

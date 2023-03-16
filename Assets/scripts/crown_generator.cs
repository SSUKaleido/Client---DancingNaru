using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crown_generator : MonoBehaviour
{
    public GameObject crown;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            //crown»ý¼º
            Instantiate(crown, transform.position, Quaternion.identity);
        }
    }
}

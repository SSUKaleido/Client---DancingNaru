using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gamePlay = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gamePlay == false)
            {
                gamePlay = true;
            }
            else 
            {
                gamePlay = false;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward);
        }

    }
}

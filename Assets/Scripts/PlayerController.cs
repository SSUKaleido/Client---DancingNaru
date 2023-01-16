using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.right);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.left);
        }
    }
}

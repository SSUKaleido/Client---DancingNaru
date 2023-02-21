using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_move : MonoBehaviour
{
    public float speed = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "crown")
        {
            Debug.Log("충돌");
            Destroy(other.gameObject); //충돌시 crown이 사라짐
        }
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = h * Vector3.right + v * Vector3.forward;

        this.transform.Translate(dir * speed * Time.deltaTime);

    }

    
}

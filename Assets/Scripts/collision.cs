using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("crown"))
        {
            print("충돌");
            Destroy(other.gameObject); //충돌시 crown이 사라짐
        }
    }
}

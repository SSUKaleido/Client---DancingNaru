using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("crown"))
        {
            print("�浹");
            Destroy(other.gameObject); //�浹�� crown�� �����
        }
    }
}

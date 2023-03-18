using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_move : MonoBehaviour
{
    public float speed = 5.0f;
    public ParticleSystem particleObject; //������ material ���� ��
    public Material[] mat = new Material[2];
    public GameObject crownObj;

    void Start()
    {
        crownObj = GameObject.Find("2d_CROWN");
    }


    public void ChangeCrownMat()
    {
        int i = 0;
        i =  ++i % 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "crown")
        {
            Debug.Log("�浹");
            Destroy(other.gameObject); //�浹�� crown�� �����

            particleObject.Play(); //��ƼŬ �ý��� ����(�������� ����)
            ChangeCrownMat();
            
        }

        
    }    
}

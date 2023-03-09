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

        //change material
        crownObj.GetComponent<MeshRenderer>().material = mat[i];
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

    // Update is called once per frame
    //ť���̵�
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = h * Vector3.right + v * Vector3.forward;

        this.transform.Translate(dir * speed * Time.deltaTime);

    }

    
}

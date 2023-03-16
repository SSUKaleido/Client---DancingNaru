using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_move : MonoBehaviour
{
    public float speed = 5.0f;
    public ParticleSystem particleObject1; //������ material ���� ��
    public ParticleSystem particleObject2; //������ material ���� ��
    public ParticleSystem particleObject3; //������ material ���� ��

    public Material[] mat = new Material[2];
    public GameObject crownObj1;
    public GameObject crownObj2;
    public GameObject crownObj3;

    void Start()
    {
        crownObj1 = GameObject.Find("2d_CROWN_1");
        crownObj2 = GameObject.Find("2d_CROWN_2");
        crownObj3 = GameObject.Find("2d_CROWN_3");
    }

    //2d crown�� ���� �ٲٰ� �ϴ� �Լ�
    //material�� �̹����� �����ؼ� ���� ä������ ���� ȿ���� ���̵��� ��
    public void ChangeCrownMat1()
    {
        int i = 0;
        i =  ++i % 2;

        //change material
        crownObj1.GetComponent<MeshRenderer>().material = mat[i];
    }
    public void ChangeCrownMat2()
    {
        int i = 0;
        i = ++i % 2;

        //change material
        crownObj2.GetComponent<MeshRenderer>().material = mat[i];
    }
    public void ChangeCrownMat3()
    {
        int i = 0;
        i = ++i % 2;

        //change material
        crownObj3.GetComponent<MeshRenderer>().material = mat[i];
    }

    //cube�� crown�浹�� ��Ÿ���� ȿ��
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "crown")
        {
            Debug.Log("�浹");
            Destroy(other.gameObject); //�浹�� crown�� �����

            particleObject1.Play(); //��ƼŬ �ý��� ����(�������� ����)
            ChangeCrownMat1();

        }

        if (other.gameObject.tag == "crown2")
        {
            Debug.Log("�浹");
            Destroy(other.gameObject); //�浹�� crown�� �����

            particleObject2.Play(); //��ƼŬ �ý��� ����(�������� ����)
            ChangeCrownMat2();

        }

        if (other.gameObject.tag == "crown3")
        {
            Debug.Log("�浹");
            Destroy(other.gameObject); //�浹�� crown�� �����

            particleObject3.Play(); //��ƼŬ �ý��� ����(�������� ����)
            ChangeCrownMat3();

        }

        
    }

    



    //ť���̵�
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = h * Vector3.right + v * Vector3.forward;

        this.transform.Translate(dir * speed * Time.deltaTime);

    }

    
}

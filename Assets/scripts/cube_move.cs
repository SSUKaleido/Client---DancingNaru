using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_move : MonoBehaviour
{
    public float speed = 5.0f;
    public ParticleSystem particleObject1; //변경할 material 넣을 곳
    public ParticleSystem particleObject2; //변경할 material 넣을 곳
    public ParticleSystem particleObject3; //변경할 material 넣을 곳

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

    //2d crown의 색을 바꾸게 하는 함수
    //material의 이미지를 변경해서 색이 채워지는 듯한 효과가 보이도록 함
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

    //cube와 crown충돌시 나타나는 효과
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "crown")
        {
            Debug.Log("충돌");
            Destroy(other.gameObject); //충돌시 crown이 사라짐

            particleObject1.Play(); //파티클 시스템 실행(빛무리가 나옴)
            ChangeCrownMat1();

        }

        if (other.gameObject.tag == "crown2")
        {
            Debug.Log("충돌");
            Destroy(other.gameObject); //충돌시 crown이 사라짐

            particleObject2.Play(); //파티클 시스템 실행(빛무리가 나옴)
            ChangeCrownMat2();

        }

        if (other.gameObject.tag == "crown3")
        {
            Debug.Log("충돌");
            Destroy(other.gameObject); //충돌시 crown이 사라짐

            particleObject3.Play(); //파티클 시스템 실행(빛무리가 나옴)
            ChangeCrownMat3();

        }

        
    }

    



    //큐브이동
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = h * Vector3.right + v * Vector3.forward;

        this.transform.Translate(dir * speed * Time.deltaTime);

    }

    
}

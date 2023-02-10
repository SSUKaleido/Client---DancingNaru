using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public bool playerMove = true;

    // 게임오버 판정
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어 움직임
        Move();
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(0, 1, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        IsGameOver();
        if (isGameOver == true)
        {
            print("Game Over");
        }
    }

    // 특정 장애물과 충돌했을 때 죽음 판정
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 3)
        {
            isGameOver = true;
        }
    }

    //플레이어가 isGrounded인지 확인: 땅과 닿아있으면 true, 땅에서 떨어지면 false
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up);
    }

    public void IsGameOver()
    {
        if (IsGrounded() == false)
        {
            isGameOver = true;
        }
    }


    

    //플레이어 움직임
    private void Move()
    {
        if (playerMove == true && Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (playerMove == true && Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (playerMove == true && Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (playerMove == true && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    // private IEnumerator falling()
    // {
    //     while (transform.position.y > -3)
    //     {
    //         transform.Translate(Vector3.forward * speed * Time.deltaTime);
    //         playerMove = false;
    //         yield return null;
    //     }
    //     playerMove = true;
    // }
}
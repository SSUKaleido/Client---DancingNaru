using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 게임오버 판정
    private bool isGameOver;
    public bool IsGameOver{
        get { return isGameOver;}
        set { isGameOver = value;
        if(isGameOver)
        {
            StageManager.instance.GameOver();
        }}
    }

    private GameObject CameraPoint;

    // private CameraController CameraControllerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        CameraPoint = GameObject.Find("CameraPoint");
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        if (isGameOver == true)
        {
            print("Game Over");
            CameraPoint.GetComponent<CameraController>().state = CameraController.CameraState.Stop;
        }
    }

    // 특정 장애물과 충돌했을 때 죽음 판정
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 3)
        {
            IsGameOver = true;
        }
    }

    //플레이어가 isGrounded인지 확인: 땅과 닿아있으면 true, 땅에서 떨어지면 false
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up);
    }

    public void GameOver()
    {
        if (IsGrounded() == false)
        {
            IsGameOver = true;
        }
    }
}
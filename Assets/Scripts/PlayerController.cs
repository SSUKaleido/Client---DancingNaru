using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // 게임오버 판정
    private bool isGameOver;
    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        {
            isGameOver = value;
            if (isGameOver)
            {
                StageManager.instance.GameOver();
            }
        }
    }

    public GameObject UI_GameOverCanvas;   //게임 오버 시 UI 출현
    public TextMeshProUGUI rateText;
    public Image rateImg;
    private GameObject CameraPoint;
    private LineController LineControllerScript;    //LineController 스크립트
    private Rigidbody playerRigidBody;  //Rigidbody 속성
    public ParticleSystem deathEffect;  //충돌 시 파편 효과
    private float force = 5;    // 플레이어 튕겨나가는 정도


    // Start is called before the first frame update
    void Start()
    {
        CameraPoint = GameObject.Find("CameraPoint");
        LineControllerScript = GameObject.Find("Pivot - Head").GetComponent<LineController>();
        playerRigidBody = GetComponent<Rigidbody>();
        UI_GameOverCanvas.SetActive(false);
      //  rateText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        
        if (isGameOver) //&& !UI_GameOverCanvas.activeSelf)
        {
            CameraPoint.GetComponent<CameraController>().state = CameraController.CameraState.Stop; //카메라 멈춤
            StartCoroutine(ActiveGameUI()); // UI 화면 활성화
        }
    }

    // 특정 장애물과 충돌했을 때 죽음 판정
    private void OnCollisionEnter(Collision other)
    {
        LayerMask collisionLayer = LayerMask.NameToLayer("Obstacle");
        //int collisionIntLayer = 1 << collisionLayer;
        
        if (other.gameObject.layer == collisionLayer)
        {
            IsGameOver = true;

            Destroy(LineControllerScript);  //LineController 스크립트 작동 불가

            // 충돌 시 애니메이션
            playerRigidBody.AddForce(new Vector3(0,1,0) * force, ForceMode.Impulse);   // 뒤로 튕겨나가는 효과
            playerRigidBody.AddTorque(new Vector3(0,1,0) * 100, ForceMode.Impulse); // 회전하는 효과
            Instantiate(deathEffect, transform.position, Quaternion.identity);  //파티클 효과
        }
    }

    //플레이어가 isGrounded인지 확인(땅과 닿아있으면 true, 땅에서 떨어지면 false)
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up);
    }

    public void GameOver()
    {
        if (IsGrounded() == false && !IsGameOver)
        {
            IsGameOver = true;
        }
    }

    // GameOverUI 
    IEnumerator ActiveGameUI()
    {
        yield return new WaitForSeconds(1.5f);
        UI_GameOverCanvas.SetActive(true);
        InDataManager();
    }

    void InDataManager()
    {
        float Rate = DataManager.Instance.LoadStageData(1).Cleared;
        int RateInt = Mathf.CeilToInt(Rate);

        rateImg.fillAmount = Rate / 100f;
        
        rateText.text = RateInt + "%";
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    public LineController controller;

    public AudioSource audio;

    public GameObject clearCube;
    public GameObject startCube;

    public GameObject CameraPoint;
    private CameraController CameraControllerScript;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        StartCoroutine(CoStartGame());
    }

    IEnumerator CoStartGame()
    {
        while (true)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
            {
                audio.Play();
                controller.StartLineProgress();

                break;
            }

            yield return null;
        }
    }

    public void GameOver()
    {
        controller.StopPlayer();

        //Camera Enidng Animation
        switch (SceneManager.GetActiveScene().name)
        {
            case "Stage_1_Scene":
                CameraPoint.GetComponent<CameraController>().panValue = 135;
                CameraPoint.GetComponent<CameraController>().state = CameraController.CameraState.Pan;
                break;

            case "Stage_2_Scene":
                CameraPoint.GetComponent<CameraController>().zoomValue = 65;
                CameraPoint.GetComponent<CameraController>().state = CameraController.CameraState.Zoom;
                break;
            case "Stage_3_Scene":
                CameraPoint.GetComponent<CameraController>().boomValue = 5;
                CameraPoint.GetComponent<CameraController>().state = CameraController.CameraState.Boom;
                break;
        }
        
        float clearDist = Vector3.Distance(clearCube.transform.position, startCube.transform.position);
        float userDist = Vector3.Distance(controller.transform.position, startCube.transform.position);

        float resDist = userDist / clearDist;
        resDist *= 100f;
        DataManager.Instance.SetClearRate(resDist);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    public LineController controller;

    public AudioSource audio;

    public GameObject clearCube;
    public GameObject startCube;

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

    public void GameOver(float dist = -1)
    {
        float resDist = 0;
        if (dist == -1)
        {
            controller.StopPlayer();

            float clearDist = Vector3.Distance(clearCube.transform.position, startCube.transform.position);
            float userDist = Vector3.Distance(controller.transform.position, startCube.transform.position);
            
            resDist = userDist / clearDist;
        }
        else
        {
            resDist = 1;
            GameObject.Find("CameraPoint").GetComponent<CameraController>().state = CameraController.CameraState.Stop; 
        }
        
        resDist *= 100f;
        
        DataManager.Instance.SetClearRate(resDist);
    }
}
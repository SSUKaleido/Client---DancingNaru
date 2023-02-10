using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    public LineController controller;

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
                controller.StartLineProgress();

                break;
            }
            
            yield return null;

        }
    }
}

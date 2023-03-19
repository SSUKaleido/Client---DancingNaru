using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class District : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        print("District.cs의 OntriggerEnter() 실행");
        BackgroundAnimation[] BgAnimations = GetComponentsInChildren<BackgroundAnimation>();

        for (int i = 0; i < BgAnimations.Length; i++)
        {
            print(BgAnimations[i]);
            BgAnimations[i].TriggerAnimation();
        }
    }
}

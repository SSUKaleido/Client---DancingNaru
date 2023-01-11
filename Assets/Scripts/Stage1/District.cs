using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class District : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BGAnimation[] BgAnimations = GetComponentsInChildren<BGAnimation>();

        for (int i = 0; i < BgAnimations.Length; i++)
        {
            BgAnimations[i].TriggerAnimation();
        }
    }
}

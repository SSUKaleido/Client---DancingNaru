using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallerAnim : MonoBehaviour
{
    float time;

    void Update()
    {
        transform.localScale = Vector3.one * (1 - time);
        if (time > 1f)
        {
            time = 0;
            gameObject.SetActive(false);
        }
        time += Time.deltaTime;
    }

    public void resetAnim()
    {
        time = 0;
        transform.localScale = Vector3.one;
    }
}

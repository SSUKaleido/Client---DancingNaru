using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TitleBGQuad : MonoBehaviour
{
    public float minSize;
    public float maxSize;

    public float minRotSpeed;
    public float maxRotSpeed;

    private float rotSpeed;

    public float minGravity;
    public float maxGravity;

    private float speed;

    public float minOpacity;
    public float maxOpacity;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        // Set Size
        transform.localScale = Vector3.one * Random.Range(minSize, maxSize);
        
        // Set Opacity
        Color c = Color.black;
        c.a = Random.Range(minOpacity, maxOpacity);
        GetComponent<MeshRenderer>().material.color = c;
        
        // Set speed
        speed = Random.Range(minGravity, maxGravity);

        // Set Rot Speed
        rotSpeed = Random.Range(minRotSpeed, maxRotSpeed);
    }

    private void FixedUpdate()
    {
        transform.localPosition += Vector3.down * speed;
        transform.Rotate(Vector3.forward * rotSpeed);
    }
}

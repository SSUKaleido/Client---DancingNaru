using System;
using System.Collections;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private bool _isTouching = false;

    public float speed;
    public GameObject cubeObj;
    
    private GameObject curObj;
    private bool _isGameOver = false;

    void Awake()
    {
        StartLineProgress();
    }

    void StartLineProgress()
    {
        InstantiateCube();
        StartCoroutine(CoControl());
    }

    IEnumerator CoControl()
    {
        while (!_isGameOver)
        {
            if (Input.touchCount == 0) _isTouching = false;

            GetTouch();
            MoveLine();

            yield return null;
        }
    }

    void ChangeDirection()
    {
        if (Math.Abs(transform.eulerAngles.y - 90) < 0.1f)
        {
            transform.Rotate(Vector3.down * 90f);
        }
        else
        {
            transform.Rotate(Vector3.up * 90f);
        }
        
        InstantiateCube();
    }

    void GetTouch()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            if (_isTouching) return;

            _isTouching = true;
            ChangeDirection();
        }

        if (Input.touchCount > 0)
        {
            if (_isTouching) return;

            _isTouching = true;
            ChangeDirection();
        }
    }

    void MoveLine()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
        curObj.transform.position += transform.forward * (speed * Time.deltaTime / 2);
        curObj.transform.localScale += transform.forward * (speed * Time.deltaTime);
    }

    void InstantiateCube()
    {
        curObj = Instantiate(cubeObj, transform.position, Quaternion.identity);
    }

    void StopPlayer()
    {
        
    }
}
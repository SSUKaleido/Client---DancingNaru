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

    private void Awake()
    {
        InstantiateCube();
    }

    public void StartLineProgress()
    {
        InstantiateCube();
        StartCoroutine(CoControl());
    }

    IEnumerator CoControl()
    {
        while (true)
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

        if (!_isGameOver)
        {
            curObj.transform.position += transform.forward * (speed * Time.deltaTime / 2);
            curObj.transform.localScale += transform.forward * (speed * Time.deltaTime);
        }
    }

    void InstantiateCube()
    {
        if(_isGameOver) return;
        curObj = Instantiate(cubeObj, transform.position, Quaternion.identity);
    }

    public void StopPlayer()
    {
        _isGameOver = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        string targetLayer = LayerMask.LayerToName(collision.gameObject.layer);
        if (targetLayer.Contains("Clear"))
        {
            
        }
    }
}
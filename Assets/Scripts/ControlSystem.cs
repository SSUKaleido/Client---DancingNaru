using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    public GameObject Map; // Put the Map Object to get data
    public LineSystem MapData;

    bool isTouched;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTouch();
        CheckClick();
        MovePlayer();
    }

    void Instantiate() 
    {
        MapData = Map.GetComponent<LineSystem>();
        isTouched = false;
        transform.position = Map.transform.position + new Vector3(0, 1, 0);
    }

    void MovePlayer() // Get the gamespeed of the map data and move the player.
    {
        if (!isTouched)
        {
            transform.position += new Vector3(MapData.gameSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(0, 0, MapData.gameSpeed * Time.deltaTime);
        }
    }

    void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (isTouched)
                {
                    isTouched = false;
                } else
                {
                    isTouched = true;
                }
            }
        }
    }

    void CheckClick()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) // When the left mouse button is pressed or the space bar is pressed
        {
            if (isTouched)
            {
                isTouched = false;
            } else
            {
                isTouched = true;
            }
        }
    }
}

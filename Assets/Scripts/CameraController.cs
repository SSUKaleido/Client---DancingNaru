using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float speed = 5.0f;
    private Vector3 offset;
    private GameObject mainCamera;
    private Vector3 initialCameraPos;


    public bool isFollowing = true;

    public bool isZoom = false;
    public float zoomValue = 1;

    public bool isPan = false;
    public float panValue = 0;

    public bool isDown = false;
    


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = transform.GetChild(0).gameObject;
        initialCameraPos = mainCamera.transform.localPosition;

        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //pos = transform.eulerAngles.x;

        if (isFollowing == true)
        {
            Following();
        }

        if (isZoom == true)
        {
            Zoom();
        }

        if (isPan == true)
        {
            Pan();
        }
        
        // if (isDown == true)
        // {
        //     Down();
        // }
    }

    void Following()
    {
        transform.position = player.transform.position + offset;
    }

    // zoomValue가 1 이상이면 줌인, 1 이하이면 줌아웃
    void Zoom() 
    {
        
        if (zoomValue >= 1 && mainCamera.transform.localPosition.z <= initialCameraPos.z / zoomValue)
        {
            mainCamera.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (zoomValue <= 1 && mainCamera.transform.localPosition.z >= initialCameraPos.z / zoomValue)
        {
            mainCamera.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

    }
    void Pan()
    {
        if (panValue >= 0 && transform.eulerAngles.y <= panValue)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
        else if (panValue <= 0 && transform.eulerAngles.y >= panValue)
        {
            transform.Rotate(Vector3.down * Time.deltaTime * speed);
        }
    }

    // void Down() // stage2 00:38
    // {

    //     if (transform.eulerAngles.x >= 350 | transform.eulerAngles.x == 0)
    //     {
    //         print("!");
    //         transform.Rotate(Vector3.left * 5 * Time.deltaTime);
    //     }

    // }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 pos;
    public GameObject player;
    public float speed = 5.0f;
    private Vector3 offset;
    private GameObject mainCamera;
    private Vector3 initialCameraPos;


    public bool isFollowing = true;

    public bool isZoom = false;
    public float zoomValue = 1;

    public bool isPanRight = false;
    public float panRightValue = 0;
    public bool isPanLeft = false;
    public float panLeftValue = 0;

    public bool isTiltUp = false;
    public float tiltUpValue = 0;
    public bool isTiltDown = false;
    public float tiltDownValue = 0;

    public bool isBoom = false;
    public float boomValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = transform.GetChild(0).gameObject;
        initialCameraPos = mainCamera.transform.localPosition;

        pos = transform.position;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isFollowing == true)
        {
            Following();
        }

        if (isZoom == true)
        {
            Zoom();
        }

        if (isPanRight == true)
        {
            PanRight();
        }

        if (isPanLeft == true)
        {
            PanLeft();
        }

        if (isTiltUp == true)
        {
            TiltUp();
        }

        if (isTiltDown == true)
        {
            TiltDown();
        }

        if (isBoom == true)
        {
            Boom();
        }
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

    void PanRight()
    {
        float rotationY = Mathf.Round(transform.eulerAngles.y);
        // 현재 각도가 원하는 각도보다 큰 경우 360도까지 회전
        if (rotationY > panRightValue && rotationY <= 360)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }

        if (rotationY < panRightValue)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
            if (rotationY >= panRightValue)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, panRightValue, transform.eulerAngles.z);
            }
        }
    }

    void PanLeft()
    {
        float rotationY = Mathf.Round(transform.eulerAngles.y);
        // 현재 각도가 원하는 각도보다 작은 경우 0도까지 회전
        if (rotationY < panLeftValue && rotationY >= 0)
        {
            transform.Rotate(Vector3.down * Time.deltaTime * speed);
        }

        if (rotationY > panLeftValue)
        {
            transform.Rotate(Vector3.down * Time.deltaTime * speed);
            if (rotationY <= panLeftValue)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, panLeftValue, transform.eulerAngles.z);
            }
        }
    }

    void TiltUp()
    {
        float rotationX = Mathf.Round(transform.eulerAngles.x);
        print(rotationX);

        if (rotationX < tiltUpValue && rotationX >= 0)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * speed);
        }

        if (rotationX > tiltUpValue)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * speed);
            if (rotationX <= tiltUpValue)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, tiltUpValue, transform.eulerAngles.z);
            }
        }
    }

    void TiltDown()
    {
        float rotationX = Mathf.Round(transform.eulerAngles.x);
        print(rotationX);

        if (rotationX > tiltDownValue && rotationX <= 360)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * speed);
        }

        if (rotationX < tiltDownValue)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * speed);
            if (rotationX >= tiltDownValue)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, tiltDownValue, transform.eulerAngles.z);
            }
        }
    }

    void Boom()
    {
        float positionY = Mathf.Round(transform.position.y);
        if (positionY < boomValue)
        {
            offset = offset + (Vector3.up * speed * Time.deltaTime);
            // mainCamera.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        else if (positionY > boomValue)
        {
            offset = offset + (Vector3.down * speed * Time.deltaTime);
            // mainCamera.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

}

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
    private Camera cameraComponent;
    private Vector3 initialCameraPos;

    public float zoomValue;
    public float panValue = 0;
    public float tiltValue = 0;

    public float boomValue = 0;

    public enum CameraState  {Following, Zoom, Pan, Tilt, Boom};
    public CameraState state;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = transform.GetChild(0).gameObject;
        cameraComponent = mainCamera.GetComponent<Camera>();
        zoomValue = mainCamera.GetComponent<Camera>().fieldOfView;
        
        initialCameraPos = mainCamera.transform.localPosition;

        pos = transform.position;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch(state)
        {
            case CameraState.Following:
                Following();
                break;

            case CameraState.Zoom:
                Zoom();
                break;

            case CameraState.Pan:
                Pan();
                break;

            case CameraState.Tilt:
                Tilt();
                break;

            case CameraState.Boom:
                Boom();
                break;
        }
    }

    void Following()
    {
        transform.position = player.transform.position + offset;
    }

    // zoomValue가 1 이상이면 줌인, 1 이하이면 줌아웃
    void Zoom()
    {
        cameraComponent.fieldOfView = Mathf.Lerp(cameraComponent.fieldOfView, zoomValue, speed * Time.deltaTime);
    }

    void Pan()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.LerpAngle(transform.eulerAngles.y, panValue, speed * Time.deltaTime), transform.eulerAngles.z); 
    }

    void Tilt()
    {
        transform.eulerAngles = new Vector3(Mathf.LerpAngle(transform.eulerAngles.x, tiltValue, speed * Time.deltaTime), transform.eulerAngles.y, transform.eulerAngles.z);
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

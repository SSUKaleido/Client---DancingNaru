using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Vector3 offset;
    private GameObject mainCamera;
    private Camera cameraComponent;
    private Vector3 initialCameraPos;

    public float zoomValue;
    public float panValue = 0;
    public float tiltValue = 0;

    public float boomValue = 0;

    public enum CameraState { Following, Zoom, Pan, Tilt, Boom };
    public CameraState state;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = transform.GetChild(0).gameObject;
        cameraComponent = mainCamera.GetComponent<Camera>();
        zoomValue = mainCamera.GetComponent<Camera>().fieldOfView;

        initialCameraPos = mainCamera.transform.localPosition;

        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (state)
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
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, boomValue, speed * Time.deltaTime), transform.position.z);
    }
    
    // IEnumerator BoomCoroutine()
    // {
    //     transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, boomValue, speed * Time.deltaTime), transform.position.z);
    //     yield return new WaitUntil(() => Mathf.Round(transform.position.y) == boomValue);
    // }
}

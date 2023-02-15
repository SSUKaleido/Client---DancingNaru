using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private GameObject CameraPoint;
    public GameObject canvas;   //게임 오버 시 UI 출현
    public void ActiveGameOverUI()
    {
        CameraPoint.GetComponent<CameraController>().state = CameraController.CameraState.Stop;
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.5f);
        canvas.SetActive(true);
    }
}

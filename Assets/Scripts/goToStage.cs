using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goToStage : MonoBehaviour
{
    private Button button;
    public Scrollbar scrollbar;
    private const int SIZE = 3;
    private float[] pos = new float[SIZE];
    private float distance;

    public void OnClickButton()
    {
        if (gameObject.transform.parent.name == "Map1")
        {
            Debug.Log("스테이지1 이동");
            //SceneManager.LoadScene("stage1");
        }

        if (gameObject.transform.parent.name == "Map2")
        {
            Debug.Log("스테이지2 이동");
            //SceneManager.LoadScene("stage2");
        }

        if (gameObject.transform.parent.name == "Map3")
        {
            Debug.Log("스테이지3 이동");
            //SceneManager.LoadScene("stage3");
        }
    }

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
        button.interactable = false;

        distance = 0.5f;
        pos[0] = 0f;
        pos[1] = 0.5f;
        pos[2] = 1f;
    }

    void Update()
    {
        if (button.interactable)
            button.interactable = false;

    }

    IEnumerator ButtonOn()
    {
        while (scrollbar.value < 1.1f && scrollbar.value > 0.9f)
        {
            button.interactable = true;
            yield return null;
        }


        while (scrollbar.value < 0.6f && scrollbar.value > 0.4f)
        {
            button.interactable = true;
            yield return null;
        }


        while (scrollbar.value < 0.1f && scrollbar.value > -0.1f)
        {
            button.interactable = true;
            yield return null;
        }
    }

}
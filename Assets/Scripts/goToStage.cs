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
    private float[] pos = new float[3];

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
        
        pos[0] = 0f;
        pos[1] = 0.5f;
        pos[2] = 1f;
    }

    void Update()
    {
        StartCoroutine(ButtonOn());
    }

    IEnumerator ButtonOn()
    {
        if (button.interactable)
            button.interactable = false;
        
        if (gameObject.transform.parent.name == "Map1")
            while (scrollbar.value < 1.1f && scrollbar.value > 0.9f) 
            {
                button.interactable = true;
                yield return null;
            }

        if (gameObject.transform.parent.name == "Map2")
            while (scrollbar.value < 0.6f && scrollbar.value > 0.4f)
            {
                button.interactable = true;
                yield return null;
            }

        if (gameObject.transform.parent.name == "Map3")
            while (scrollbar.value < 0.1f && scrollbar.value > -0.1f)
            { 
                button.interactable = true;
                yield return null;
            }
    }
}
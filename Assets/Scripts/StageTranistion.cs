using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageTranistion : MonoBehaviour
{
    private Button button_Stage;
    public Scrollbar scrollbar;
    private float[] pos = new float[3];

    public void OnClickButton()
    {
        if (gameObject.transform.parent.name == "Map1")
        {
           // SceneManager.LoadScene("stage1");
        }

        if (gameObject.transform.parent.name == "Map2")
        {
            //SceneManager.LoadScene("stage2");
        }

        if (gameObject.transform.parent.name == "Map3")
        {
           //SceneManager.LoadScene("stage3");
        }
    }

    void Start()
    {
        button_Stage = GetComponent<Button>();
        button_Stage.onClick.AddListener(OnClickButton);
        button_Stage.interactable = false;
        
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
        if (button_Stage.interactable)
            button_Stage.interactable = false;
        
        if (gameObject.transform.parent.name == "Map1")
            while (scrollbar.value < 1.1f && scrollbar.value > 0.9f) 
            {
                button_Stage.interactable = true;
                yield return null;
            }
        
        if (gameObject.transform.parent.name == "Map2")
            while (scrollbar.value < 0.6f && scrollbar.value > 0.4f)
            {
                button_Stage.interactable = true;
                yield return null;
            }
        
        if (gameObject.transform.parent.name == "Map3")
            while (scrollbar.value < 0.1f && scrollbar.value > -0.1f)
            { 
                button_Stage.interactable = true;
                yield return null;
            }
    }
}
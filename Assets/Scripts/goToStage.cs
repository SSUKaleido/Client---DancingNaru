using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goToStage : MonoBehaviour
{
    private Button button;
    
    public void OnClickButton()
    {
        
    }
    
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }
    
    void Update()
    {
        
    }
}

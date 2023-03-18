using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressButton: MonoBehaviour
{
    public GameObject canvas;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        canvas.SetActive(false);
    }
    
    public void Back()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

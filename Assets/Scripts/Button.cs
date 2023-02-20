using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject canvas;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        canvas.SetActive(false);

    }
    public void Back()
    {
        // SceneManager.LoadScene("");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnim : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private float[] pos = new float[5];
    public Scrollbar scrollbar;
    private Color currentColor;
    private float fadeInValue = 0.6f;
    
    
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        currentColor = _meshRenderer.material.color;
        if (this.GameObject() != GameObject.Find("Map1"))
        {
            currentColor.a = fadeInValue;
            _meshRenderer.material.color = currentColor;
        }

        pos[0] = 0f;
        pos[1] = 0.25f;
        pos[2] = 0.5f;
        pos[3] = 0.75f;
        pos[4] = 1f;
    }
    
    void Update()
    {
        if (this.GameObject() == GameObject.Find("Map3"))
        {
            Color fadeInColor = _meshRenderer.material.color;
            while (scrollbar.value < pos[3] && scrollbar.value >= pos[2])
            {
                fadeInColor.a = fadeInValue + scrollbar.value;
                _meshRenderer.material.color = fadeInColor;
            }
        }
    }
}

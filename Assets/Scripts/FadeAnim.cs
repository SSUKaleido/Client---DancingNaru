using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnim : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _meshRenderer;
    private const int SIZE = 3;
    private float[] pos = new float[SIZE];
    public Scrollbar scrollbar;
    private List<Color> currentColor = new List<Color>();
    public float firstValue = 0.5f;

    public GameObject parentTransfrom;

    void Start()
    {
        _meshRenderer = transform.GetComponentsInChildren<MeshRenderer>();
        if (_meshRenderer.Length == 0)
        {
            Destroy(GetComponent<FadeAnim>());
        }

        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            currentColor.Add(_meshRenderer[i].material.color);
        }


        for (int i = 0; i < _meshRenderer.Length; i++)
            if (parentTransfrom.name != "stage1")
            {
                Color c = currentColor[i];
                c.a = firstValue;
                currentColor[i] = c;
                _meshRenderer[i].material.color = currentColor[i];
            }
    }

    void Update()
    {
        StartCoroutine(FadeUp());
        StartCoroutine(FadeDown());
    }


    IEnumerator FadeUp()
    {
        {
            if (parentTransfrom.name == "stage2")
            {
                while (scrollbar.value < 1f && scrollbar.value >= 0.5f)
                    for (int i = 0; i < _meshRenderer.Length; i++)
                    {
                        Color c = currentColor[i];
                        c.a = firstValue + ((1 / scrollbar.value) - 1f); //0-1
                        if (currentColor[i].a >= 1f)
                            c.a = 1f;

                        currentColor[i] = c;
                        _meshRenderer[i].material.color = currentColor[i];

                        yield return null;
                    }
            }
        }

        if (parentTransfrom.name == "stage3")
        {
            while (scrollbar.value < 0.5f && scrollbar.value >= 0f)
                for (int i = 0; i < _meshRenderer.Length; i++)
                {
                    Color c = currentColor[i];
                    c.a = firstValue + ((1 / (scrollbar.value + 0.5f)) - 1f);
                    if (currentColor[i].a >= 1f)
                        c.a = 1f;

                    currentColor[i] = c;
                    _meshRenderer[i].material.color = currentColor[i];

                    yield return null;
                }
        }
    }

    public void CallFadeDown()
    {
        StartCoroutine(FadeDown());
    }

    IEnumerator FadeDown()
    {
        if (parentTransfrom.name == "stage1")
            while (scrollbar.value < 1f && scrollbar.value >= 0.5f)
            {
                for (int i = 0; i < _meshRenderer.Length; i++)
                {
                    Color c = currentColor[i];
                    c.a = 2f - (1 / scrollbar.value); //0-1
                    if (c.a <= 0.6f)
                        c.a = 0.6f;

                    Debug.Log(c.a);
                    
                    currentColor[i] = c;
                    _meshRenderer[i].material.color = currentColor[i];

                    yield return null;
                }
            }

        if (parentTransfrom.name == "stage2")
            while (scrollbar.value < 0.5f && scrollbar.value >= 0f)
                for (int i = 0; i < _meshRenderer.Length; i++)
                {
                    Color c = currentColor[i];
                    c.a = 1f - ((1 / (scrollbar.value + 0.5f)) - 1f); //0.5-0
                    if (currentColor[i].a <= 0.6f)
                        c.a = 0.6f;

                    currentColor[i] = c;
                    _meshRenderer[i].material.color = currentColor[i];

                    yield return null;
                }
    }
}
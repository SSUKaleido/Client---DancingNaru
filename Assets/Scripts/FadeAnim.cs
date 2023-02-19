using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnim : MonoBehaviour
{
    private MeshRenderer[] _meshRenderer;
    private const int SIZE = 3;
    private float[] pos = new float[SIZE];
    public Scrollbar scrollbar;
    private Color[] currentColor;
    public float firstValue = 0.5f;


    void Start()
    {

        _meshRenderer = transform.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < _meshRenderer.Length; i++)
        {
            currentColor[i] = _meshRenderer[i].material.color;
        }



        for (int i = 0; i < _meshRenderer.Length; i++)
            if (gameObject.transform.parent.name != "stage1")
            {
                currentColor[i].a = firstValue;
                _meshRenderer[i].material.color = currentColor[i];
            }

        pos[0] = 0f;
        pos[1] = 0.5f;
        pos[2] = 1f;
    }

    void Update()
    {
        StartCoroutine(FadeUp());
        StartCoroutine(FadeDown());
    }


    IEnumerator FadeUp()
    {
        for (int i = 0; i < _meshRenderer.Length; i++)
            if (gameObject.transform.parent.name == "stage2" || gameObject.transform.parent.parent.name == "stage2")
                while (scrollbar.value < 1f && scrollbar.value >= 0.5f)
                {
                    currentColor[i].a = firstValue + ((1 / scrollbar.value) - 1f); //0-1
                    if (currentColor[i].a >= 1f)
                        currentColor[i].a = 1f;

                    _meshRenderer[i].material.color = currentColor[i];

                    yield return null;
                }

        for (int i = 0; i < _meshRenderer.Length; i++)
            if (gameObject.transform.parent.name == "stage3" || gameObject.transform.parent.parent.name == "stage3")
            {
                while (scrollbar.value < 0.5f && scrollbar.value >= 0f)
                {
                    currentColor[i].a = firstValue + ((1 / (scrollbar.value + 0.5f)) - 1f);
                    if (currentColor[i].a >= 1f)
                        currentColor[i].a = 1f;

                    _meshRenderer[i].material.color = currentColor[i];

                    yield return null;
                }
            }
    }

    IEnumerator FadeDown()
    {
        for (int i = 0; i < _meshRenderer.Length; i++)
            if (gameObject.transform.parent.name == "stage1" || gameObject.transform.parent.parent.name == "stage1")
                while (scrollbar.value < 1f && scrollbar.value >= 0.5f)
                {
                    currentColor[i].a = 1f - ((1 / scrollbar.value) - 1f); //0-1
                    if (currentColor[i].a <= 0.6f)
                        currentColor[i].a = 0.6f;

                    _meshRenderer[i].material.color = currentColor[i];

                    yield return null;
                }

        for (int i = 0; i < _meshRenderer.Length; i++)
            if (gameObject.transform.parent.name == "stage2" || gameObject.transform.parent.parent.name == "stage2")
                while (scrollbar.value < 0.5f && scrollbar.value >= 0f)
                {
                    currentColor[i].a = 1f - ((1 / (scrollbar.value + 0.5f)) - 1f); //0.5-0
                    if (currentColor[i].a <= 0.6f)
                        currentColor[i].a = 0.6f;

                    _meshRenderer[i].material.color = currentColor[i];

                    yield return null;
                }
    }
}



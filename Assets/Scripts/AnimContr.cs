using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimContr : MonoBehaviour
{
    private Animator _animator;
    public Scrollbar scrollbar;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 0.0f;
    }

    void Update()
    {
        StartCoroutine(AnimOn());
    }
    
    
    IEnumerator AnimOn()
    {
        if (_animator.speed != 0.0f)
            _animator.speed = 0.0f;
        
        if (gameObject.transform.parent.name == "stage1"|| gameObject.transform.parent.parent.name == "stage1")
            while (scrollbar.value < 1.1f && scrollbar.value > 0.9f)
            {
                _animator.speed = 1.0f;
                yield return null;
            }

        if (gameObject.transform.parent.name == "stage2" || gameObject.transform.parent.parent.name == "stage2")
            while (scrollbar.value < 0.6f && scrollbar.value > 0.4f)
            {
                _animator.speed = 1.0f;
                yield return null;
            }

        if (gameObject.transform.parent.name == "stage3" || gameObject.transform.parent.parent.name == "stage3")
            while (scrollbar.value < 0.1f && scrollbar.value > -0.1f)
            { 
                _animator.speed = 1.0f;
                yield return null;
            }
    }
}

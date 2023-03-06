using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackHoleControl : MonoBehaviour
{
    private Animation _animation;
    public Scrollbar scrollbar;
    
    void Start()
    {
        _animation = GetComponent<Animation>();
    }

    void Update()
    {
        StartCoroutine(AnimationOn());
    }
    
    IEnumerator AnimationOn()
    {
        if (_animation["portal_anim"].speed != 0.0f)
            _animation["portal_anim"].speed = 0.0f;
        
        while (scrollbar.value < 0.6f && scrollbar.value > 0.4f)
        {
            _animation["portal_anim"].speed = 1.0f;
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_CompUp : MonoBehaviour
{
    public float speed = 2.0f;
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y / 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        ComeUp(height);
    }

    void ComeUp(float Height)
    {
        if (transform.position.y < Height)
        {
            transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
        }
    }
}

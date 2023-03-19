using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_Rotate : BackgroundAnimation
{
    public float speed = 30.0f; //speed 값이 양수이면 오른쪽으로, 음수이면 왼쪽으로 이동
    private bool animationOn = false;
    public Vector3 rotateAxis = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        Vector3[] positions = new Vector3[renderers.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = renderers[i].bounds.center;
        }

        if (animationOn == true)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                transform.RotateAround(positions[i], rotateAxis, speed * Time.deltaTime);
            }
        }
    }

    public override void TriggerAnimation() 
    {
        animationOn = true;
    }
}

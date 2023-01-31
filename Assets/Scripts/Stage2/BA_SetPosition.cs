using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_SetPosition : BackgroundAnimation
{
    public float speed = 10;
    public Vector3 targetPos;   // 원위치
    public Vector3 randomPos;   // 랜덤위치
    private float distance = 10.0f;

    private bool animationOn = false;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        float randomX = Random.Range(targetPos.x - distance, targetPos.x + distance);
        float randomZ = Random.Range(targetPos.z - distance, targetPos.z + distance);

        //랜덤 위치로 오브젝트 재배치
        randomPos = new Vector3(randomX, transform.position.y, randomZ);
        transform.position = randomPos;   
    }

    // Update is called once per frame
    void Update()
    {
        if (animationOn == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    public override void TriggerAnimation()
    {
        animationOn = true;
    }
}

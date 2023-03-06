using UnityEngine;

public class QuadSetter : MonoBehaviour
{
    
    
    private void OnCollisionEnter(Collision collision)
    {
        print("On Collision Enter!!");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("On Trigger Enter!!");
    }

    private void OnTriggerExit(Collider other)
    {
        // Set position to init pos
        other.transform.position = new Vector3(0, 2200, 600);
        other.GetComponent<TitleBGQuad>().Init();
    }
}

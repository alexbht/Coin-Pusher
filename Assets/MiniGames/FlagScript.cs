using UnityEngine;

public class Colliz : MonoBehaviour
{
    public Material Mat;


    void OnTriggerEnter(Collider other)
    {
        Renderer r = GetComponent<Renderer>();
        Renderer objectRenderer = other.gameObject.GetComponent<Renderer>();
        if (objectRenderer.name == "Car")
        {
            r.material = Mat;
        }

    }

    void OnTriggerExit(Collider other)
    {
        Renderer r = GetComponent<Renderer>();
        Renderer objectRenderer = other.gameObject.GetComponent<Renderer>();
        if (objectRenderer.name == "Car"){
            r.material = Mat;
        }
    }
}
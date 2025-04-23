using UnityEngine;

public class Pusher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float dT = Time.time;
        Vector3 pos = transform.position;
        Rigidbody rb = GetComponent<Rigidbody>();
        pos.z = Mathf.Sin((2*Mathf.PI/ 5) * dT );
        rb.MovePosition(pos); 
    }
}

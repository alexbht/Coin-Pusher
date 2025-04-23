using UnityEngine;

public class Pusher : MonoBehaviour
{
    private float originalZ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalZ = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dT = Time.time;
        Vector3 pos = transform.position;
        Rigidbody rb = GetComponent<Rigidbody>();
        pos.z = originalZ + Mathf.Sin((2*Mathf.PI/ 5) * dT );
        rb.MovePosition(pos); 
    }
}

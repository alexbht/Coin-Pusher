using UnityEngine;

public class carcontrol : MonoBehaviour
{
    public float turnSpeed = 180;
    public float maxSpeed = 100;
    void Start() { }

    void Update()
    {
        float v = Input.GetAxis("Horizontal");
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        transform.Rotate(0, dt * hInput * 30, 0);
        transform.Translate(Vector3.left*maxSpeed * dt * vInput);

        Debug.Log(v);
    }
}
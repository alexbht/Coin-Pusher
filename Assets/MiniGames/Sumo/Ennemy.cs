using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Windows;

public class Ennemy : MonoBehaviour
{
    public float maxSpeed = 7;
    public float intensity;
    private Rigidbody rb;
    private GameObject Player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dT = Time.deltaTime;
        Vector3 direction = (Player.transform.position - transform.position).normalized;
        rb.AddForce(direction * intensity * dT);
       
        Vector3 velocity = rb.linearVelocity;

        if (velocity.magnitude > maxSpeed)
            rb.linearVelocity = velocity.normalized * maxSpeed;

    }
}

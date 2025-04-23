using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int intensity;
    public int maxSpeed = 10;
    public Boolean hasPowerUp = false;
    public GameObject PowerUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dT = Time.deltaTime;
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * intensity * dT * vInput);

        Vector3 velocity = rb.linearVelocity;
        Debug.Log(velocity.magnitude);

        if (velocity.magnitude > maxSpeed)
            rb.linearVelocity = velocity.normalized * maxSpeed;

        GameObject cam = GameObject.Find("Main Camera");
        GameObject center = GameObject.Find("Focal point");
        Vector3 V = center.transform.position - cam.transform.position;
        V.y = 0; // horizontal vector
        V.Normalize();
        Vector3 V2 = Quaternion.Euler(0, 90, 0) * V;
        rb.AddForce(V2 * intensity * dT * hInput);

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Power up") Destroy(other.gameObject);
        hasPowerUp = true;
        PowerUp.SetActive(true);
        StartCoroutine(EndPowerup());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy") && hasPowerUp)
        {
            Rigidbody ennemyRb = collision.rigidbody.GetComponent<Rigidbody>();
            Ennemy ennemyScript = collision.rigidbody.GetComponent<Ennemy>();
            Vector3 Push = (collision.transform.position - transform.position).normalized;
            ennemyRb.AddForce(Push * 8000);
            StartCoroutine(Stun(ennemyScript));
        }
    }

    IEnumerator EndPowerup()
    {
        yield return new WaitForSeconds(5);

        hasPowerUp = false;
        PowerUp.SetActive(false);
    }

    IEnumerator Stun(Ennemy ennemy)
    {
        ennemy.enabled = false;
        yield return new WaitForSeconds(1);

        ennemy.enabled = true;
    }
}

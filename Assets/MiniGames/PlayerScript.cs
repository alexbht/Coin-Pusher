using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float VitessePlayer = 8;
    public GameObject pizzaSlice;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis("Horizontal");
        if (transform.position.z > 4.8)
        {
            if (hInput > 0)
            {
                transform.Translate(Vector3.back * VitessePlayer * dt * hInput);
            }
        }
        else if(transform.position.z < -4.8){
            if (hInput < 0)
            {
                transform.Translate(Vector3.back * VitessePlayer * dt * hInput);
            }
        }
        else
        {
            transform.Translate(Vector3.back * VitessePlayer * dt * hInput);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(pizzaSlice, transform.position, transform.rotation);
        };
    }
}

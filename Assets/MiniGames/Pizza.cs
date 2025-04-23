using UnityEngine;

public class Pizza : MonoBehaviour
{
    public float VitessePizza = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        transform.Translate(Vector3.right * VitessePizza * dt);

        if(transform.position.x > 8)
        {
            Destroy(gameObject);
        }
    }
}

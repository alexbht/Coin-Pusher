using UnityEngine;

public class Clockhands : MonoBehaviour
{
    public enum HandType { Hour, Minute, Second }
    public HandType handType;

    public float speedMultiplier = 1f;

    void Update()
    {
        float rotationSpeed = 0f;

        switch (handType)
        {
            case HandType.Hour:
                rotationSpeed = 360f / 43200f;
                break;
            case HandType.Minute:
                rotationSpeed = 360f / 3600f;  
                break;
            case HandType.Second:
                rotationSpeed = 360f / 60f;   
                break;
        }

        transform.Rotate(Vector3.right, -rotationSpeed * speedMultiplier * Time.deltaTime);
    }
}

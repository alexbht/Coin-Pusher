using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Transform crosshair;      // Reference to the Quad (Crosshair)
    public float fixedHeight = 1.5f; // Fixed height of the crosshair above the surface
    public GameObject coinPrefab;    // Reference to the coin prefab
    public float coinSpeed = 5f;     // Speed of the coin's initial fall

    void OnMouseOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Vector3 target = hit.point;
                target.y = fixedHeight;
                crosshair.position = target;
            }
        }
    }

    void OnMouseDown()
    {
        // Detect click and spawn a coin at the position of the crosshair
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                // Instantiate the coin at the crosshair position
                Vector3 spawnPosition = hit.point;
                spawnPosition.y = fixedHeight;  // Ensure the coin is at the correct height

                GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 90f));

                // Apply initial velocity to the coin to make it fall faster
                Rigidbody coinRb = coin.GetComponent<Rigidbody>();
                if (coinRb != null)
                {
                    coinRb.linearVelocity = new Vector3(0f, coinSpeed, 0f);  // Fall straight down (adjust y velocity)
                }
            }
        }
    }
}

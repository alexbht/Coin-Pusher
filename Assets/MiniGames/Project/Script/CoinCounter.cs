using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int coinCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Debug.Log("Coins Collected: " + coinCount);

            Destroy(other.gameObject); // Supprime la pièce si tu veux
        }
    }
}

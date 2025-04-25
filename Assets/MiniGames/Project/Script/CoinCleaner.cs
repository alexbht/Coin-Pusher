using UnityEngine;

public class CoinCleaner : MonoBehaviour
{
    public float checkInterval = 0.2f;        // Temps entre les vérifications
    public float minY = -3.5f;               // Position trop basse = pièce supprimée
    public float raycastDistance = 0.1f;    // Distance du raycast vers le bas

    private void Start()
    {
        InvokeRepeating(nameof(CheckCoin), Random.Range(0f, 0.5f), checkInterval);
    }

    void CheckCoin()
    {
        // Vérification si la pièce est trop basse
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
            return;
        }

        // Lancer un raycast vers le bas
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, raycastDistance))
        {
            string hitName = hit.collider.gameObject.name.ToLower();

            // Supprimer la pièce si elle atterrit sur une surface interdite
            if (hitName.Contains("cube") || hitName.Contains("chip"))
            {
                Destroy(gameObject);
            }
        }
    }
}

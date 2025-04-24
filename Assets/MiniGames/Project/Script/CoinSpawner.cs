using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class MultiCoinSpawner : MonoBehaviour
{
    [Header("Coin Prefabs")]
    public GameObject[] coinPrefabs; // 3 types différents

    [Header("Spawn Settings")]
    public float coinsPerSecond = 10f;

    private BoxCollider boxCollider;
    private Transform coinParent;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;

        // Trouver ou créer le parent "CoinsRoot"
        GameObject root = GameObject.Find("CoinsRoot");
        if (root == null)
        {
            root = new GameObject("CoinsRoot");
            root.transform.position = Vector3.zero;
        }

        coinParent = root.transform;

        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        float waitTime = 1f / coinsPerSecond;

        while (true)
        {
            Vector3 spawnPos = GetRandomPointInside();

            GameObject selectedPrefab = coinPrefabs[Random.Range(0, coinPrefabs.Length)];
            Quaternion flatRotation = Quaternion.Euler(90f, 0f, 0f);

            Instantiate(selectedPrefab, spawnPos, flatRotation, coinParent);

            yield return new WaitForSeconds(waitTime);
        }
    }

    Vector3 GetRandomPointInside()
    {
        Vector3 size = boxCollider.size;
        Vector3 center = boxCollider.center;

        Vector3 localRandom = new Vector3(
            Random.Range(-size.x / 2f, size.x / 2f),
            Random.Range(-size.y / 2f, size.y / 2f),
            Random.Range(-size.z / 2f, size.z / 2f)
        );

        return boxCollider.transform.TransformPoint(center + localRandom);
    }
}

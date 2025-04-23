using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] alienPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float startDelay = 2;
        float spawnInterval = 3;
        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        int r = Random.Range(0, 3);
        Vector3 V = alienPrefabs[r].transform.position;
        V.z = Random.Range(-5, 5);
        Instantiate(alienPrefabs[r], V, alienPrefabs[r].transform.rotation);
    }
}

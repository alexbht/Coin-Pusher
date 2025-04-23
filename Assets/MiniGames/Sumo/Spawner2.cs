using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Spawner2 : MonoBehaviour
{
    public GameObject monsterPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomNumberx = UnityEngine.Random.Range(-20f, 7f);
        float randomNumberz = UnityEngine.Random.Range(-15f, 7f);
        Instantiate(monsterPrefab, new Vector3(randomNumberx, 8, randomNumberz), monsterPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}

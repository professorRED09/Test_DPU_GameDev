using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    public GameObject[] itemList;

    void Start()
    {        
        // start spawning npc when the game starts
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        // while the script is working, after the delay time is out, spawn enemy with given position and rotation 
        while (true)
        {
            float delay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(delay);

            GameObject itemPrefab = itemList[Random.Range(0, itemList.Length - 1)];
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }
}

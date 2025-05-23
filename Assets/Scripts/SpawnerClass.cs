using UnityEngine;
using System.Collections;

public class SpawnerClass : MonoBehaviour
{
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    private GameObject enemyPrefab;

    void Start()
    {
        // โหลด prefab ศัตรู
        enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");

        if (enemyPrefab == null)
        {
            Debug.LogError("ไม่พบ Prefab: Resources/Prefabs/Enemy");
            return;
        }
        
        // start spawning enemy when the game starts
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        // while the script is working, after the delay time is out, spawn enemy with given position and rotation 
        while (true)
        {
            float delay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(delay);

            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}

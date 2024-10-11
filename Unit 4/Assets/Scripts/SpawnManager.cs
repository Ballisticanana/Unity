using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount = 1;
    public int waveNumber = 1;
    private bool gameStart = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemyWave", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart == true)
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if (enemyCount == 0)
            {
                waveNumber += 1;
                SpawnEnemyWave(waveNumber);
            }
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i += 1)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        Instantiate(powerupPrefab, GenerateSpawnPosition() / 2, powerupPrefab.transform.rotation);
    }
    void SpawnEnemyWave()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); 
        Instantiate(powerupPrefab, GenerateSpawnPosition() / 2, powerupPrefab.transform.rotation);
        gameStart = true;
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);
        return randomPos;
    }
}
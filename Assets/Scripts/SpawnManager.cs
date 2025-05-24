using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(3);
    }

    // Update is called once per frame
    void Update()
    {
#pragma warning disable CS0618 // O tipo ou membro � obsoleto
        enemyCount = FindObjectsOfType<Enemies>().Length;
#pragma warning restore CS0618 // O tipo ou membro � obsoleto

        if (enemyCount == 0)
        {
            SpawnEnemyWave(1);
        }
    }

    void SpawnEnemyWave(int enemies)
    {
        for (int i = 0; i < enemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

}

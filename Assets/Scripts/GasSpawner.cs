using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GasSpawner : MonoBehaviour
{
    public BoxCollider gasSpawnPoint;
    public GameObject gasPrefab;
    private float timer = 0;
    private float gasSpawnTime = 0.5f;


    private void Update()
    { 
        timer += Time.deltaTime;
        if (timer > gasSpawnTime)
        {
            SpawnGas();
        }
    }

    void SpawnGas()
    {
        Vector3 spawnPos = new Vector3(Random.Range(gasSpawnPoint.bounds.min.x, gasSpawnPoint.bounds.max.x),
            gasSpawnPoint.transform.position.y, gasSpawnPoint.transform.position.z);
        GameObject spawnedGas = Instantiate(gasPrefab, spawnPos, Quaternion.identity);
        timer = 0;
    }
}

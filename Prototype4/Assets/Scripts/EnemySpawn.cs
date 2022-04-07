using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefab;

    public int spawnRange = 9;

    private void Start()
    {
        Vector3 spawnPos = GenerateSpawnPos(spawnRange);

        Instantiate(prefab, spawnPos, prefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPos(int range)
    {
        float randX = UnityEngine.Random.Range(-range, range);
        float randY = UnityEngine.Random.Range(-range, range);
        Vector3 spawnPos = new Vector3(randX, 0, randY);

        return spawnPos;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public HealthManager healthManager;
    public GameObject[] prefabs;

    private float leftBound = -14, rightBound = 14, zPosition = 20;

    void Start()
    {
        healthManager = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthManager>();
        StartCoroutine(SpawnRandomPrefabCoroutine());
    }

    IEnumerator SpawnRandomPrefabCoroutine()
    {
        yield return new WaitForSeconds(3f);

        while (!healthManager.gameOver)
        {
            SpawnRandomPrefab();

            yield return new WaitForSeconds(1.5f);
        }
    }

    void SpawnRandomPrefab()
    {
        int prefabIndex = Random.Range(0, prefabs.Length);

        Vector4 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, zPosition);

        Instantiate(prefabs[prefabIndex], spawnPos, prefabs[prefabIndex].transform.rotation);
    }
}

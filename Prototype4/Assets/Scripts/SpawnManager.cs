using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab, powerUpPrefab;

    [SerializeField] private PlayerController player;

    private UIWriter UI;

    public int spawnRange = 9, enemyCount = 0, waveNumber = 1;

    private void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<UIWriter>();
    }

    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0 && !player.gameOver && !UI.tutorial)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber / 2);
            SpawnPowerUp(1);
        }

        if (waveNumber >= 10)
        {
            player.gameOver = true;
        }
    }

    private Vector3 GenerateSpawnPos(int range)
    {
        float randX = UnityEngine.Random.Range(-range, range);
        float randY = UnityEngine.Random.Range(-range, range);
        Vector3 spawnPos = new Vector3(randX, 0, randY);

        return spawnPos;
    }

    public void SpawnEnemyWave(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(spawnRange), enemyPrefab.transform.rotation);
        }
    }

    public void SpawnPowerUp(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Instantiate(powerUpPrefab, GenerateSpawnPos(spawnRange), powerUpPrefab.transform.rotation);
        }
    }
}

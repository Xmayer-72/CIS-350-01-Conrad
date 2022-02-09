/*
 * Conrad Mayer
 * Prototype 3
 * Spawns obstacles in the way of the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float startDelay, repeatDelay;

    private PlayerController level;
    private Vector3 spwanPos = new Vector3(25, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
    }

    void SpawnObstacle()
    {
        if (!level.gameOver)
        {
            int index = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[index], spwanPos, obstaclePrefabs[index].transform.rotation);
        }
    }
}

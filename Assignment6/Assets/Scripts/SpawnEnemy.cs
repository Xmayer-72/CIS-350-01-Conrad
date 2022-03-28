using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Enemy[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("createEnemiesCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator createEnemiesCoroutine()
    {
        while (true)
        {
            createEnemies();
            yield return new WaitForSeconds(Random.Range(1,5));
        }
    }

    void createEnemies()
    {
        Enemy toSummon = enemies[Random.Range(0, enemies.Length)];
        int summonAngle = Random.Range(1, 361);

        Instantiate(toSummon, angleToVector(summonAngle, 50), new Quaternion(0, 0, 0, 0));
    }

    Vector3 angleToVector(int angle, int radius)
    {
        float xCord = radius * Mathf.Sin(angle), yCord = radius * Mathf.Cos(angle);

        Vector3 result = new Vector3(xCord, 2, yCord);

        return result;
    }
}

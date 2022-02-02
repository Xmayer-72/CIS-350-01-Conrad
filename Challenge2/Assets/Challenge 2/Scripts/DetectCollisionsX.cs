/*
 * Conrad Mayer
 * Challenge 2
 * destroys objects that they collide with
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private HealthScoreManager healthScore;

    private void Start()
    {
        healthScore = GameObject.FindGameObjectWithTag("HealthScore").GetComponent<HealthScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        healthScore.scoreAdd();
        Destroy(gameObject);
    }
}

/*
 * Conrad Mayer
 * Protoype 3
 * Moves obstacles to the left at speed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float speed, leftBound;

    private PlayerController level;

    private void Start()
    {
        level = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!level.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody enemyRb;

    private GameObject player;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 looking = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(looking * speed);
    }
}

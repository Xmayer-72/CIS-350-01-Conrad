using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bit : Enemy
{
    void Start()
    {
        speed = 10;
        health = 5;

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);

        if (Vector3.Distance(transform.position, Player.transform.position) <= attackDistance)
        {
            Attack();
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    //melee attack
    protected override void Attack()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bit : Enemy
{

    void Start()
    {
        speed = 8;
        health = 5;
        attackDistance = 5;

        Glow = GetComponentInChildren<Light>();

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);

        if (Vector3.Distance(transform.position, Player.transform.position) <= attackDistance && attackDelay <= 0)
        {
            Attack();
            Glow.gameObject.SetActive(false);
            attackDelay = 10;
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (attackDelay > 0)
        {
            attackDelay -= Time.deltaTime;
        }
        else
        {
            Glow.gameObject.SetActive(true);
        }
    }

    //melee attack
    protected override void Attack()
    {
        //bit attacks and deals damage
        Player.GetComponent<Movement>().Damage(5);
    }
}

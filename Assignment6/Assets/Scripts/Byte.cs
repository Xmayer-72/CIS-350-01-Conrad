using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Byte : Enemy
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
        health = 15;
        attackDistance = 25;

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
            attackDelay = 30;
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

    //ranged Attack
    protected override void Attack()
    {
        //shoots projectile at player
        Instantiate(projectile, transform.position, transform.rotation);
    }
}

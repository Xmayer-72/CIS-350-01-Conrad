using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Byte : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
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

    //ranged Attack
    protected override void Attack()
    {

    }
}

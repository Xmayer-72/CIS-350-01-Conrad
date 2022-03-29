using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 20, attackDelay;
    public int health = 30;
    public GameObject playerModel;
    public ParticleSystem boom;

    // Update is called once per frame
    void Update()
    {
        //Move Player
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * speed * Time.deltaTime);
        playerModel.transform.LookAt(transform.position + movement);

        if (Input.GetButton("Fire1") && attackDelay <= 0)
        {
            boom.Play();

            attackDelay = 2;

            Collider[] Targets = Physics.OverlapSphere(transform.position, 5);

            foreach (Collider target in Targets)
            {
                if (target.GetComponent<Enemy>() != null)
                {
                    target.GetComponent<Enemy>().Damage(10);
                }
            }
        }

        if (attackDelay > 0)
        {
            attackDelay -= Time.deltaTime;
        }
    }

    public void Damage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}

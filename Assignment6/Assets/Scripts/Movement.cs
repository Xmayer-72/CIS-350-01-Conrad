using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 20;
    public int health = 30;
    public GameObject playerModel;
    public GameObject projectile;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        //Move Player
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * speed * Time.deltaTime);
        playerModel.transform.LookAt(transform.position + movement);

        if (Input.GetButton("Fire1"))
        {
            Instantiate(projectile, transform.position, playerModel.transform.rotation);
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

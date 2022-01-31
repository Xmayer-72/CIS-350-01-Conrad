using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horizontalInput, speed = 10.0f, xRange = 14;

    // Update is called once per frame
    void Update()
    {
        //get input
        horizontalInput = Input.GetAxis("Horizontal");

        //move player based on input
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //keep player bounded
        if(transform.position.x < -xRange || transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange * Mathf.Sign(horizontalInput), transform.position.y, transform.position.z);
        }
    }
}

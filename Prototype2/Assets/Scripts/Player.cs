/*
 * Conrad Mayer
 * 1/31/22
 * Prototype2
 * control player and movement therein
 */

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
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed, Space.World);

        //rotate based on horizontal input
        transform.rotation = Quaternion.Euler(0, horizontalInput*25, 0);

        //keep player bounded
        if (transform.position.x < -xRange || transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange * Mathf.Sign(transform.position.x), transform.position.y, transform.position.z);
        }
    }
}
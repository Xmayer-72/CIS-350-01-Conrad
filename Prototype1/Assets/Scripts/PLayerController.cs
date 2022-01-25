/*
 * Conrad Mayer
 * 1/24/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, turnSpeed, horizontalInput, forwardInput;

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //move player forward speed units per second
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //rotate player turnSpeed units per second
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput * forwardInput);
    }
}

/*
 * Conrad Mayer
 * Challenge 1
 * Allows contol of the player / rotates the propeller
 * 1/26/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject prop;
    public float speed;
    public float propMult;
    public float rotationSpeed;
    public float verticalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // Rotate the prop in accordace to the current speed and a specified multiplier
        prop.transform.Rotate(Vector3.forward * speed * Time.deltaTime * propMult);

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * -verticalInput);
    }
}

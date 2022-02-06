/*
 * Conrad Mayer
 * Challenge 1
 * Follows the plane with the camera
 * 1/26/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //set camera offset
        offset = new Vector3(25, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move camera to plane + offset
        transform.position = plane.transform.position + offset;

        //coppy the rotation of the plane in one plane | personal preference
        //transform.rotation = Quaternion.LookRotation(transform.forward, plane.transform.up);
    }
}

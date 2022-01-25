/*
 * Conrad Mayer
 * 1/24/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    public int speed;

    private Vector3 offset = new Vector3(0, 5, -7);

    // Update is called once per frame
    void Update()
    {
        //if (transform.position != player.transform.position + offset)
        Vector3 diff = transform.position - (player.transform.position + offset);

        transform.Translate(-diff * Time.deltaTime * speed);
    }
}

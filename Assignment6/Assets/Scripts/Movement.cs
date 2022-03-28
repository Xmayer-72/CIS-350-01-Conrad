using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 20;
    public GameObject playerModel;

    // Update is called once per frame
    void Update()
    {
        //Move Player
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(movement * speed * Time.deltaTime);
        playerModel.transform.LookAt(transform.position + movement);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementForce;

    private Rigidbody rb;

    private GameObject focal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focal = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");

        rb.AddForce(movementForce * verticalInput * focal.transform.forward, ForceMode.Force);
    }
}

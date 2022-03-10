using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * Z;
        controller.Move(movement * speed * Time.deltaTime);
    }
}

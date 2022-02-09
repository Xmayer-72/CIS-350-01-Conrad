/*
 * Conrad Mayer
 * Prototype 3
 * Controlls player movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody self;

    public float jumpForce, gravityMod;
    public ForceMode jumpForceMode;

    public bool onGround, gameOver;

    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.GetComponent<Rigidbody>();

        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityMod;
        }

        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && onGround && !gameOver)
        {
            self.AddForce(Vector3.up * jumpForce, jumpForceMode);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            onGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            gameOver = true;
            Debug.Log("Game Over");
        }
    }
}

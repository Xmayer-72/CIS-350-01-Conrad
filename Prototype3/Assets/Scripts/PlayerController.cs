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
    private Animator PlayerAnim;

    public ParticleSystem explosionParticle, mudParticle;

    public AudioClip jumpSound, crashSound;

    private AudioSource playerAudio;

    public float jumpForce, gravityMod;
    public ForceMode jumpForceMode;

    public bool onGround, gameOver;

    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.GetComponent<Rigidbody>();

        PlayerAnim = GetComponent<Animator>();
        PlayerAnim.SetFloat("Speed_f", 1f);
        PlayerAnim.SetInteger("DeathType_int", 2);

        playerAudio = GetComponent<AudioSource>();

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
            mudParticle.Stop();

            PlayerAnim.SetTrigger("Jump_trig");

            playerAudio.PlayOneShot(jumpSound, 1.0f);

            self.AddForce(Vector3.up * jumpForce, jumpForceMode);
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            onGround = true;
            mudParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            explosionParticle.Play();
            mudParticle.Stop();

            playerAudio.PlayOneShot(crashSound, 1f);

            PlayerAnim.SetBool("Death_b",true);
            
            gameOver = true;
            Debug.Log("Game Over");
        }
    }
}

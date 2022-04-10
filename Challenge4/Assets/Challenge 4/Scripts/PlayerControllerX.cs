using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 500, boost = 40;
    private GameObject focalPoint;
    private SpawnManagerX spawn;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public ParticleSystem boostParticle;
    public int powerUpDuration = 5;

    private float normalStrength = 10; // how hard to hit enemy without powerup
    private float powerupStrength = 25; // how hard to hit enemy with powerup
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnManagerX>();
    }

    void Update()
    {
        if (spawn.gameOver)
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            // Add force to player in direction of the focal point (and camera)
            float verticalInput = Input.GetAxis("Vertical");
            playerRb.AddForce(speed * Time.deltaTime * verticalInput * focalPoint.transform.forward);

            // Set powerup indicator position to beneath player
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

            if (Input.GetKeyDown(KeyCode.Space))
        {
                playerRb.AddForce(boost * Time.deltaTime * focalPoint.transform.forward, ForceMode.Impulse);
                spawn.tutorial = false;
                boostParticle.Play();
            }
        }
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
           
            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
                enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }


        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;

    private float minSpeed = 12, maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float yPos = -3;

    public int scoreVal;

    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = gameObject.GetComponent<Rigidbody>();

        RandomXPosition(targetRB, yPos);
        RandomTorque(targetRB);
        RandomForce(targetRB);
    }

    private void RandomXPosition(Rigidbody rb, float spawnPos)
    {
        rb.position = new Vector3(Random.Range(-xRange, xRange), spawnPos);
    }

    private void RandomTorque(Rigidbody rb)
    {
        rb.AddTorque(new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque)));
    }

    private void RandomForce(Rigidbody rb)
    {
        rb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.isGameActive)
            {
            GameManager.Instance.UpdateScore(scoreVal);

            Instantiate(explosion, transform.position, explosion.transform.rotation);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            if (gameObject.CompareTag("Good"))
            {
                GameManager.Instance.GameOver();
            }
            Destroy(gameObject);
        }
    }
}

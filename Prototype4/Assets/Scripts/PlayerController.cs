using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementForce, powerUpStrength;

    private Rigidbody rb;

    private GameObject focal;
    public GameObject powerUpIndicator;

    public bool hasPowerUp;

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

        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.4f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(powerUpCountdown());
            powerUpIndicator.SetActive(true);
        }
    }

    private IEnumerator powerUpCountdown()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("PLayer collided with " + collision.gameObject.name + " With PowerUp status " + hasPowerUp);

            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 away = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRB.AddForce(away * powerUpStrength, ForceMode.Impulse);
        }
    }
}

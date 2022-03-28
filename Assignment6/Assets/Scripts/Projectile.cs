using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Trigger");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Movement>().Damage(10);
        }

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("damage enemy");
            other.GetComponent<Enemy>().Damage(5);
        }
    }
}

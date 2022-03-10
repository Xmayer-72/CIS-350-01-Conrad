using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHitScan : MonoBehaviour
{
    public float damage = 10f, range = 100f, hitForce = 10f;
    public Camera cam;
    public ParticleSystem muzzleFlash;

    private void Start()
    {
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.gameObject.name);

            Target target = hitInfo.transform.gameObject.GetComponent<Target>();

            if (target != null)
            {
                target.takeDamage(damage);
            }

            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}

/*
 * Conrad Mayer
 * Challenge 2
 * Manage player interaction with game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    //minimum time in seconds between dogs
    public float DogWait = 2;

    private float lastDog;

    void Start()
    {
        lastDog = DogWait;
    }

    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && lastDog >= DogWait)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastDog = 0;
        }

        //itterate dogwait
        lastDog += (Time.deltaTime);
    }
}

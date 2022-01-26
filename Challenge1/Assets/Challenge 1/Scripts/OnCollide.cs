/*
 * Conrad Mayer
 * Challenge 1
 * Updates score when colliding with a scoreZone
 * 1/26/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollide : MonoBehaviour
{
    //variable to ensure only one addition per collision
    private bool triggered;
    private void OnTriggerEnter(Collider other)
    {
        //if the collided object is tagged as the player and this is the first collision
        if (other.CompareTag("Player") && !triggered)
        {
            //show as triggered
            triggered = true;

            //add to score
            ScoreManager.score++;
        }
    }
}

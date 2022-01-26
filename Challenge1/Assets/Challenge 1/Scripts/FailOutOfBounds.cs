/*
 * Conrad Mayer
 * Challenge 1
 * Ends game if player is out of bounds
 * 1/26/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailOutOfBounds : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //checks if the plane is outside of bouds
        if (transform.position.y >= 70 || transform.position.y <= -50)
        {
            //if out of bounds, end the game
            ScoreManager.gameOver = true;
        }
    }
}

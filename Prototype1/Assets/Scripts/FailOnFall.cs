/*
 * Conrad Mayer
 * 1/24/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Attatch to player
public class FailOnFall : MonoBehaviour
{
    public Text textBox;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1)
        {
            textBox.text = "you Lose";
        }
    }
}

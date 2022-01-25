/*
 * Conrad Mayer
 * 1/24/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCollision : MonoBehaviour
{
    public Text textBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            //set text
            textBox.text = "You Won!";
        }
    }
}

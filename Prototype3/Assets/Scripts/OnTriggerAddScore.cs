/*
 * Conrad Mayer
 * Prototype 3
 * increments score when colided with by player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAddScore : MonoBehaviour
{
    public UIWriter Ui;
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        Ui = GameObject.FindObjectOfType<UIWriter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            Ui.score++;
        }
    }
}

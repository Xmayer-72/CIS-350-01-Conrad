using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideFinnish : MonoBehaviour
{
    public Text textBox;

    private void Start()
    {
        textBox = GameObject.FindGameObjectWithTag("Text").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDE");
        if (other.CompareTag("Player"))
        {
            Debug.Log("WIN!");
            textBox.text = "You Win!";
        }
    }
}

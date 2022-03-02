using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOver : MonoBehaviour
{
    private Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        textBox = GameObject.FindGameObjectWithTag("Win").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textBox.text = "You Win!";
        }
    }
}

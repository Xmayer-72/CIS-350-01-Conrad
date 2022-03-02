/*
 * Conrad Mayer
 * Assignment 5a
 * Records when collected the gems and increments score
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private Text textBox;

    private bool scored = false;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!scored)
        {
            score++;
            scored = true;
        }
    }

    private void Update()
    {
        textBox.text = "Score: " + score;
    }
}

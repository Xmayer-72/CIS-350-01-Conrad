using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health, maxHealth;

    public Text textBox;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<Text>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "";

        if (!gameOver) {
            for (int i = 0; i < health; i++)
            {
                textBox.text += "❤";
            }

            for (int i = maxHealth; i > health; i--)
            {
                textBox.text += "<color=#500000>❤</color>";
            }

            if (health <= 0)
            {
                gameOver = true;
            }
        }
        else {
            textBox.text = "Game Over! Press R to restart";

            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }
}

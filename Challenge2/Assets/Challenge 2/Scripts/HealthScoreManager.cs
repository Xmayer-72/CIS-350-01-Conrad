using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScoreManager : MonoBehaviour
{
    public Text textBox;

    public int maxHealth, health, score;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        health = maxHealth;
        textBox = GetComponent<Text>();
        textBox.text = "Score: 0\n❤❤❤❤❤";
    }

    // Update is called once per frame
    void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if (score >= 5)
        {
            gameOver = true;
        }
        else if(health<= 0)
        {
            gameOver = true;
        }

        if (gameOver)
        {
            if(score >= 5)
            {
                textBox.text = "You Win!\nPress R to restart";
            }
            else
            {
                textBox.text = "You Lose!\nPress R to restart";
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            textBox.text = "Score: " + score + "\n";

            for (int i = 0; i < health; i++)
            {
                textBox.text += "<color=#f00000>❤</color>";
            }

            for (int i = 0; i < maxHealth - health; i++)
            {
                textBox.text += "<color=#500000>❤</color>";
            }
        }
    }

    public void Damage()
    {
        health--;
    }

    public void scoreAdd()
    {
        score++;
    }
}

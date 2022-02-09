/*
 * Conrad Mayer
 * Prototype 3
 * Writes the UI and manages score
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWriter : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public bool won = false;

    private PlayerController level;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<Text>();

        level = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!level.gameOver)
        {
            scoreText.text = "Score: " + score;
        }
        else if (!won)
        {
            scoreText.text = "You Lose!\nPress Enter to Try Again!";
        }
        
        if(score >= 10)
        {
            level.gameOver = true;
            won = true;
            scoreText.text = "You Win!\nPress Enter to Try Again!";
        }

        if (level.gameOver && Input.GetButton("Submit"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}

/*
 * Conrad Mayer
 * Challenge 1
 * Manages the gamestate in regards to score
 * 1/26/22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //init variables
    public static bool gameOver, won;
    public static int score;

    public Text textBox;
    public int targetScore;

    //reset game variables on scene start
    private void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is continuing, keep the score updated
        if (!gameOver)
        {
            textBox.text = "Score: " + score;
        }

        //if the target score is acieved, win the game and end the game
        if (score >= targetScore)
        {
            won = true;
            gameOver = true;
        }

        //if the game is over, check what kind of end and inform player
        if (gameOver)
        {
            //if you won, tell player as such
            if (won)
            {
                textBox.text = "You Win!\nPress R to Try Again";
            }
            //otherwise, tell the player that they have lost
            else
            {
                textBox.text = "You Lose!\nPress R to Try Again";
            }

            //restart the game once it is over by pressing 'r'
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
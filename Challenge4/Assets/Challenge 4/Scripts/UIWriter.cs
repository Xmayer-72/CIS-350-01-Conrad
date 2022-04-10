using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWriter : MonoBehaviour
{
    private Text textBox;
    private SpawnManagerX spawn;

    void Start()
    {
        textBox = GetComponentInChildren<Text>();
        spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawn.tutorial)
        {
            if (spawn.gameOver)
            {
                if (spawn.waveCount >= 10)
                {
                    textBox.text = "You win! Press R to restart";
                }
                else
                {
                    textBox.text = "you lose! Press R to restart";
                }
            }
            else
            {
                textBox.text = "Wave: " + spawn.waveCount;
            }
        }
        else
        {
            textBox.text = "Knock the balls into the enemy's goal.\n"
                         + "Don't let them score in your goal.\n"
                         + "Clear 10 waves to win!\n"
                         + "Press the spacebar to Boost.";
        }
    }
}

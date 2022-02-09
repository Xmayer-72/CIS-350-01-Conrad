using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWriter : MonoBehaviour
{
    private PlayerControllerX level;
    private Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();
        textBox = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (level.score>=30)
        {
            textBox.text = "You win! Press Enter to Restart!";
            level.gameOver = true;
        }
        else if (level.gameOver)
        {
            textBox.text = "You lose! Press Enter to Restart!";
        }
        else
        {
            textBox.text = "Score: " + level.score;
        }
    }
}

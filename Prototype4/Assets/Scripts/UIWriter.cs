using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIWriter : MonoBehaviour
{
    private Text textBox;
    [SerializeField] private SpawnManager spawn;
    [SerializeField] private PlayerController player;

    public bool tutorial = true;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutorial)
        {
            textBox.text = "Wave #" + spawn.waveNumber;

            if (player.gameOver)
            {
                if (spawn.waveNumber >= 10)
                {
                    textBox.text = "You Win! Press R to try again";
                }
                else
                {
                    textBox.text = "You Lose! Press R to try again";
                }

                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
        else
        {
            textBox.text = "Make it to wave #10 to win! If you fall off, you lose\nPress Space to begin";
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tutorial = false;
            spawn.SpawnEnemyWave(1);
        }
    }
}

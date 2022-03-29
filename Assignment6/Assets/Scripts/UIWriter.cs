using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWriter : MonoBehaviour
{
    private GameObject player;
    private Slider healthBar;
    private Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        healthBar = gameObject.GetComponentInChildren<Slider>();
        textBox = gameObject.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float health = player.GetComponent<Movement>().health;

        healthBar.value = health;

        if (player.GetComponent<Movement>().health <=0)
        {
            GameManager.Instance.Pause();
            textBox.text = "GameOver! Try again from the main menu";
        }
    }
}

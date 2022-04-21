using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private GameManagerX game;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 60;

        text = GetComponent<TextMeshProUGUI>();

        game = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (game.isGameActive)
        {
            time -= Time.deltaTime;
            text.text = "Time: " + Mathf.Round(time);
        }

        if (time <= 0)
        {
            game.GameOver();
        }
    }
}

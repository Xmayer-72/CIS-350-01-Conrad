using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text textBox;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        textBox = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "Score: " + score;
    }
}

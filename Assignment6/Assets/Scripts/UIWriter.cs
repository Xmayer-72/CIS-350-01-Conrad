using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWriter : MonoBehaviour
{
    private GameObject player;
    private Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        healthBar = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float health = player.GetComponent<Movement>().health;

        healthBar.value = health;
    }
}

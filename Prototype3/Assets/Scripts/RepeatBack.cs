/*
 * Conrad Mayer
 * Prototype 3
 * Scrolls the background
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBack : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private PlayerController level;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        repeatWidth = GetComponent<BoxCollider>().size.x / 2;

        level = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!level.gameOver)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }

        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}

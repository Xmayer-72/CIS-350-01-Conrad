/*
 * Conrad Mayer
 * 1/31/22
 * Prototype2
 * create instance of food at player on keypress
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFood : MonoBehaviour
{
    public GameObject food;
    Animator CharAnim;

    void Start()
    {
        CharAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //create food
            Instantiate(food, transform.position, food.transform.rotation);
        }
    }
}

/*
 * Conrad Mayer
 * 1/31/22
 * Prototype2
 * destroy objects out of bounds
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float upperbound, lowerbound;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < lowerbound|| transform.position.z > upperbound)
        {
            Destroy(gameObject);
        }
    }
}

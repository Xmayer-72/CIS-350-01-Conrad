/*
 * Conrad Mayer
 * 1/31/22
 * Prototype2
 * Destroy object that is a trigger, then destroy self
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

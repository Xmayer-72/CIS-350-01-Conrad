using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject Player;

    public Light Glow;

    public int health;

    protected float speed, attackDistance;

    public float attackDelay = 0;

    protected abstract void Attack();

    public void Damage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            Player.GetComponent<Movement>().Damage(-5);
        }
    }
}
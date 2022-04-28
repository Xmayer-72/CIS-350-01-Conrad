using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;
using System;

public class EnemyAI : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    public GameObject player;

    public float followDist;

    private void Start()
    {
        cam = Camera.main;

        character = GetComponent<ThirdPersonCharacter>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        moveEnemy();
    }

    private void moveEnemy()
    {
        float targetDist = Vector3.Distance(transform.position, player.transform.position);

        if (targetDist > agent.stoppingDistance && targetDist < followDist)
        {
            agent.SetDestination(player.transform.position);
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            agent.SetDestination(transform.position);
            character.Move(Vector3.zero, false, false);
        }
    }
}

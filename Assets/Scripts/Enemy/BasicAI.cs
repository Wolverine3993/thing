using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float attackRadius;
    [SerializeField] float moveSpeed;
    enum State
    {
        Chasing,
        Attacking
    }
    State state = State.Chasing;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        agent.speed = moveSpeed;
    }
    void Update()
    {
        bool attackRange = Physics.CheckSphere(transform.position, attackRadius, playerLayer);
        if (attackRange)
            state = State.Attacking;
        else
            state = State.Chasing;
        switch (state)
        {
            case State.Chasing:
                Chase();
                break;
            case State.Attacking:
                Attack();
                break;
        }
    }
    void Chase()
    {
        agent.SetDestination(player.transform.position);
    }
    void Attack()
    {
        agent.SetDestination(transform.position);
    }
}

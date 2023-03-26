using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    float angularSpeed, currentSpeed;
    [SerializeField] float fastPeed, fastAngular;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float attackRadius;
    [SerializeField] float fastRange;
    [SerializeField] Object attacking;
    Animator anim;
    float timer;
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
        anim = GetComponent<Animator>();
        angularSpeed = agent.angularSpeed;
        currentSpeed = agent.speed;
    }
    void Update()
    {
        bool attackRange = Physics.CheckSphere(transform.position, attackRadius, playerLayer);
        bool fastSpeed = Physics.CheckSphere(transform.position, fastRange, playerLayer);
        if(fastSpeed)
        {
            agent.speed = currentSpeed;
            agent.angularSpeed = angularSpeed;
        }else
        {
            agent.speed = fastPeed;
            agent.angularSpeed = fastAngular;
        }
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
        timer -= Time.deltaTime;
        if (timer <= 0)
            GetComponent<Rigidbody>().isKinematic = true;
    }
    void Chase()
    {
        anim.SetBool("Running", true);
        anim.SetBool("Swing", false);
        agent.SetDestination(player.transform.position);
    }
    void Attack()
    {
        Vector3 playerPos = player.transform.position;
        transform.LookAt(new Vector3(playerPos.x, transform.position.y, playerPos.z));
        anim.SetBool("Running", false);
        anim.SetBool("Swing", true);
        agent.SetDestination(transform.position);
    }
    public void SetTimerNoKinematic(float value)
    {
        timer = value;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, fastRange);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
enum ZombieState
{
    Idle = 0,
    Walk = 1,
    Dead = 2,
    Attack = 3
}
public class ZombieYZ : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    ZombieState zombieState;
    GameObject playerObject;
    PlayerHealth playerHealth;
    ZombieHealth zombieHealth;
    
    
    // Start is called before the first frame update
    void Start()
    {
        zombieHealth = GetComponent<ZombieHealth>();
        playerObject = GameObject.FindWithTag("Player");
        playerHealth = playerObject.GetComponent<PlayerHealth>();
        zombieState = ZombieState.Idle;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (zombieHealth.GetHealth() <=0 )
        {
            Setstate(ZombieState.Dead);
            
        }
        switch (zombieState)
        {
            case ZombieState.Dead:
               
                KillZombie();
                break;
            case ZombieState.Attack:
                Attack();
                break;
            case ZombieState.Walk:
                SearchForTarget();
                break;
            case ZombieState.Idle:
                SearchForTarget();
                break;
                
            default:
                break;
        }
    }

    private void Attack()
    {
        Setstate(ZombieState.Attack);
        agent.isStopped = true;

    }

    private void MakeAttack()
    {
        playerHealth.DeductHealth(10);
        SearchForTarget();
    }   
    private void SearchForTarget()
    {
        float distance = Vector3.Distance(transform.position, playerObject.transform.position);
        if (distance < 1.5f)
        {
            Attack();
        }
        else if (distance < 20)
        {
            MoveToPlayer();
        }
        else
        {
            Setstate(ZombieState.Idle);
            agent.isStopped = true;
        }
    }

    private void Setstate(ZombieState state)
    {
        zombieState = state;
        animator.SetInteger("state", (int)state);
    }

    private void MoveToPlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(playerObject.transform.position);
        Setstate(ZombieState.Walk);

    }
    //private void GenerateZombie()
    //{
        
    //    GameObject zombie = Instantiate(zombiePrefab, new Vector3(UnityEngine.Random.Range(max, min), 0.22f, UnityEngine.Random.Range(max, min)), Quaternion.identity);

    //}
    private void KillZombie()
    {

        Setstate(ZombieState.Dead);
        agent.isStopped = true;
        Destroy(gameObject, 5);
        

    }
    
}

using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Animator animator;
    Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    public OnFloor onFloor;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        if (onFloor.isPlayeronfloor)   //(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.enabled = true;
            nav.SetDestination(player.position);
            nav.speed = 10f;
            if (animator) animator.SetBool("Attacking", true);
        }
        else
        {
            nav.enabled = false;
        }
    }

    
}

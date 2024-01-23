using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    [Header("Stats")]
    public int health = 10;
    public int aware = 10;
    Animator anim;
    private int attackingLayerIndex;
    public NavMeshAgent enemy;
    public Transform player;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (health != aware)
        {
            enemy.SetDestination(player.position);
        }

    }

}




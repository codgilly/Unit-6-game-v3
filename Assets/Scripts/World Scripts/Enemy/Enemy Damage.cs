using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyDamage
{
    public class EnemyDamage : MonoBehaviour
    {
        public float damage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PHealthBar>().TakeDamage(damage);
            }
        }
    }
}


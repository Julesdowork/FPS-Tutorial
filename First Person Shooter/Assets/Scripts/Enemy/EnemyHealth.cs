using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] EnemyStats stats;
    int currentHealth;

    void Start()
    {
        currentHealth = stats.maxHealth;
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

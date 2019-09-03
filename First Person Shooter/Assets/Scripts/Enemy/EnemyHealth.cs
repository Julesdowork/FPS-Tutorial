using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] EnemyStats stats;
    int currentHealth;
    [SerializeField] Slider healthbar;
    [SerializeField] Image healthbarFill;
    [SerializeField] Color maxHealthColor;
    [SerializeField] Color lowHealthColor;

    void Start()
    {
        currentHealth = stats.maxHealth;
        SetHealthbarUI();
    }

    public void DealDamage(float damage)
    {
        currentHealth = Mathf.FloorToInt(currentHealth - damage);
        CheckIfDead();
        SetHealthbarUI();
    }

    private void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void SetHealthbarUI()
    {
        healthbar.value = currentHealth;
        healthbarFill.color = Color.Lerp(lowHealthColor, maxHealthColor, HealthPercentage());
    }

    private float HealthPercentage()
    {
        return currentHealth / stats.maxHealth;
    }
}

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
    [SerializeField] Color maxHealthColor = Color.green;
    [SerializeField] Color lowHealthColor = Color.red;
    [SerializeField] GameObject damageTextPrefab;

    void Start()
    {
        currentHealth = stats.maxHealth;
        SetHealthbarUI();
    }

    public void DealDamage(float damage)
    {
        currentHealth = Mathf.FloorToInt(currentHealth - damage);
        GameObject damageText = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);
        damageText.transform.SetParent(transform, false);
        damageText.GetComponent<DamageText>().Initialize(Mathf.FloorToInt(damage));

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

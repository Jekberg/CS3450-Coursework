using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    private int currentHealth;

    public event Action<float> onHealthUpdate = delegate { };

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damageAmount) {
        currentHealth -= damageAmount;
        onHealthUpdate((float)currentHealth / (float)maxHealth);
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        onHealthUpdate((float)currentHealth / (float)maxHealth);
    }
}

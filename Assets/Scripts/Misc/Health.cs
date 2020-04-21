using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    public event Action<float> onHealthUpdate = delegate { };

    public int CurrentHealth
    {
        get;
        private set;
    }

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void Damage(int damageAmount) {
        CurrentHealth -= damageAmount;
        onHealthUpdate((float)CurrentHealth / (float)maxHealth);
    }

    public void Heal(int healAmount)
    {
        CurrentHealth += healAmount;
        onHealthUpdate((float)CurrentHealth / (float)maxHealth);
    }
}

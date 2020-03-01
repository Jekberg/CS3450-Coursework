using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    private int currentHealth;

    public event Action<float> onHealthUpdate = delegate { };

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damageAmount) {
        currentHealth -= damageAmount;
        onHealthUpdate((float)currentHealth / (float)maxHealth);
    }
}

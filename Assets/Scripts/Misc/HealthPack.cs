using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int healAmount;

    public void UseOn(Health health)
    {
        health.Heal(healAmount);
        Destroy(gameObject);
    }
}

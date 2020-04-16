using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int healAmount;
    [SerializeField] private float rotationSpeed;

    public void UseOn(Health health)
    {
        health.Heal(healAmount);
        Destroy(gameObject);
    }

    private void Update()
    {
        var rotation = transform.rotation.eulerAngles + transform.up * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation);
    }
}

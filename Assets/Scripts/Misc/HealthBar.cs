using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    private void Start()
    {
        GetComponentInParent<Health>().onHealthUpdate += FillHealthBar;
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }

    private void FillHealthBar(float health)
    {
        healthBar.fillAmount = health;
    }
}

using UnityEngine;

public class HowToShootTutorial : MonoBehaviour
{
    private void Awake()
    {
        GetComponentInParent<Phase>().AddObjective(gameObject, IsDead);
    }

    private bool IsDead()
    {
        return GetComponent<Health>().CurrentHealth <= 0;
    }
}

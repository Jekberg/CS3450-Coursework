using UnityEngine;

public class Defeatable : MonoBehaviour
{
    [SerializeField] private float points;

    private void Awake()
    {
        GetComponent<Health>().onHealthUpdate += HandleHealthUpdate;
    }

    private void HandleHealthUpdate(float health)
    {
        if (0.0f < health)
            return;
        GameManager.Manager.IncreaseScore(points);
        Destroy(gameObject);
    }
}

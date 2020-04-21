using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private float pushForce;

    public float PushForce
    {
        get { return pushForce; }
    }

    public int DamageAmount
    {
        get { return damageAmount; }
    }

    private NavMeshAgent Agent {get { return GetComponent<NavMeshAgent>();}}

    private void Start()
    {
        GetComponent<Health>().onHealthUpdate += HandleHealthUpdate;
    }

    private void Update()
    {
        Agent.SetDestination(PlayerController.Player.transform.position);
    }

    private void HandleHealthUpdate(float health)
    {
        if (0.0f < health)
            return;

        GameManager.Manager.IncreaseScore(10f);
        Destroy(gameObject);
    }
}

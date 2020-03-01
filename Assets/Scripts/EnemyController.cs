using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent Agent{get { return GetComponent<NavMeshAgent>();}}

    public void Start()
    {
        GetComponent<Health>().onHealthUpdate += IsDead;
    }

    public void Update()
    {
        Agent.SetDestination(PlayerManager.Player.transform.position);
    }

    private void IsDead(float health) {
        if (health < 0)
            Destroy(gameObject);
    }
}

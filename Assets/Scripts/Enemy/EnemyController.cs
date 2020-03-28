using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent Agent {get { return GetComponent<NavMeshAgent>();}}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }

    private void Start()
    {
        GetComponent<Health>().onHealthUpdate += HandleHealthUpdate;
    }

    private void Update()
    {
        Agent.SetDestination(PlayerManager.Player.transform.position);
    }

    private void HandleHealthUpdate(float health)
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}

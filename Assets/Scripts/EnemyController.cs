using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBarPrefab;

    private NavMeshAgent Agent{get { return GetComponent<NavMeshAgent>();}}

    public void Start()
    {
        Instantiate(healthBarPrefab, transform).transform.position += transform.up * 5;
    }

    public void Update()
    {
        Agent.SetDestination(PlayerManager.Player.transform.position);
    }
}

using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform target;

    public void Start()
    {
        
    }

    public void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(PlayerManager.PlayerInstance.transform.position);
    }
}

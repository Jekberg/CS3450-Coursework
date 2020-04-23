using UnityEngine;
using UnityEngine.AI;

public class BasicChaseMovement : MonoBehaviour
{
    private NavMeshAgent Agent {get { return GetComponent<NavMeshAgent>();}}

    private void Update()
    {
        Agent.SetDestination(PlayerController.Player.transform.position);
    }
}

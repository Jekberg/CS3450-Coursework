using UnityEngine;
using UnityEngine.AI;

public class FlyingMovement : MonoBehaviour {

    [SerializeField] private float distance = 10;

    private NavMeshAgent Agent
    {
        get { return GetComponent<NavMeshAgent>();  }
    }

	void Update ()
    {
        var playerLocation = PlayerController.Player.transform.position;
        Agent.SetDestination(playerLocation + (transform.position - playerLocation).normalized * distance);
	}
}

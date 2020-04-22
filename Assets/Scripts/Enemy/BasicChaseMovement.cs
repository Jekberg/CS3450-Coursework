using UnityEngine;
using UnityEngine.AI;

public class BasicChaseMovement : MonoBehaviour
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

    private void Update()
    {
        Agent.SetDestination(PlayerController.Player.transform.position);
    }
}

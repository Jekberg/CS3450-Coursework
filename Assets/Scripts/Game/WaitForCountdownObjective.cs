using UnityEngine;

public class WaitForCountdownObjective : MonoBehaviour
{
    [SerializeField] private float timeInSeconds = 10.0f;
    
    private void Awake()
    {
        GetComponentInParent<Phase>().AddObjective(gameObject, IsWaitCompleted);
    }

    private void Update()
    {
        timeInSeconds -= Time.deltaTime;
    }

    private bool IsWaitCompleted()
    {
        return timeInSeconds < 0.0f;
    }
}

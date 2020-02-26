using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    private float spawnCooldownSeconds = 10.0f;

    [SerializeField]
    private GameObject enemyPrefeb;

    private float timeSinceSpawn = 0.0f;
    
	void Update ()
    {
        if (spawnCooldownSeconds <= (timeSinceSpawn += Time.deltaTime))
        {
            timeSinceSpawn -= spawnCooldownSeconds;
            Instantiate(enemyPrefeb, transform);
        }
	}
}

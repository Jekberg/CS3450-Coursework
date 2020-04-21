﻿using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    private float spawnCooldownSeconds = 10.0f;

    [SerializeField]
    private GameObject enemyPrefeb;

    private float timeSinceSpawn = 0.0f;

    public void Start()
    {
        GetComponent<Health>().onHealthUpdate += HandleHealthUpdate;
    }

    void Update ()
    {
        if (spawnCooldownSeconds <= (timeSinceSpawn += Time.deltaTime))
        {
            timeSinceSpawn -= spawnCooldownSeconds;
            Instantiate(enemyPrefeb, transform.position, transform.rotation, transform.parent);
        }
	}

    private void HandleHealthUpdate(float health) 
    {
        if (health < 0)
        {
            GameManager.Manager.IncreaseScore(1000f);
            Destroy(gameObject);
        }
    }
}

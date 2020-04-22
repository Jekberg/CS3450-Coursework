using System.Collections;
using UnityEngine;

public class FireAtPlayer : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float fireRate;
    private float fireTimer;

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if(fireRate <= fireTimer)
        {
            fireTimer -= fireRate;
            StartCoroutine(ShootPlayerPlayer());
        }
    }

    private IEnumerator ShootPlayerPlayer()
    {
        var target = PlayerController.Player.transform.position - transform.position;
        yield return new WaitForSeconds(1);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, target.normalized, out hit))
        {
            var health = hit.collider.GetComponent<Health>();
            if (health != null)
                health.Damage(damage);
        }
    }
}

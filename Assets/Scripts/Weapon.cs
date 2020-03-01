using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform aim;

    [SerializeField]
    private uint magSize;

    [SerializeField]
    private float damage;

    [SerializeField]
    private float fireRate;

    private float x = 0;

	void Update ()
    {
        if (false)
            ;
        else if (0 < x)
            x -= Time.deltaTime;
        else if (Input.GetButton("Fire1"))
        {
            x += fireRate;
            RaycastHit hit;
            if (Physics.Raycast(aim.position, aim.forward, out hit) && hit.transform.GetComponent<Health>())
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Health>().Damage(90);
            }
        }
	}
}

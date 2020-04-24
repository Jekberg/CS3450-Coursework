using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform aim;
    [SerializeField] private float damage;
    [SerializeField] private float fireRate;
    private float x = 0;

	private void Update ()
    {
        if (0 < x)
            x -= Time.deltaTime;
        else if (Input.GetButton("Fire1"))
        {
            var audio = GetComponent<AudioSource>();
            if (audio != null)
                audio.Play();
            x += fireRate;
            RaycastHit hit;
            if (Physics.Raycast(aim.position, aim.forward, out hit))
                if(hit.transform.GetComponent<Health>()
                    && hit.collider.tag != "Player")
                {
                    Debug.Log(hit.transform.name);
                    hit.transform.GetComponent<Health>().Damage(10);
                }
        }
	}
}

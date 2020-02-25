using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefeb;
    
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.C))            
            Instantiate(enemyPrefeb, transform);
		
	}
}

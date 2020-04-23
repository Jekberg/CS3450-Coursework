using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(PlayerController.Player.transform);
    }
}

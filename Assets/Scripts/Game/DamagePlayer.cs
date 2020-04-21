using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void Start()
    {
        PlayerController.Player.Health.Damage(50);
    }
}

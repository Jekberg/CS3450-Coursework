using UnityEngine;

public class DamageOnContact : MonoBehaviour
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
}

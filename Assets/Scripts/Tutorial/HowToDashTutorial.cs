using UnityEngine;

public class HowToDashTutorial : MonoBehaviour
{
    private bool hasDahsed = false;

    private void Awake()
    {
        GetComponentInParent<Phase>().AddObjective(gameObject, HasDashed);
    }

    private void Update()
    {
        hasDahsed = hasDahsed ? true : Input.GetMouseButton(1);
    }

    private bool HasDashed()
    {
        return hasDahsed;
    }
}

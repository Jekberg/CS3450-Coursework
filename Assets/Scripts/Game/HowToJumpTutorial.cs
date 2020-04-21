using UnityEngine;

public class HowToJumpTutorial : MonoBehaviour
{
    private bool hasJumped = false;

    private void Awake()
    {
        GetComponentInParent<Phase>().AddObjective(gameObject, HasJumped);
    }

    private void Update()
    {
        hasJumped = Input.GetKeyDown(KeyCode.Space);
    }

    private bool HasJumped()
    {
        return hasJumped;
    }
}

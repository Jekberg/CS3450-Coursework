using UnityEngine;

public class HowToMoveTutorial : MonoBehaviour
{
    private bool hasMoved = false;

    private void Awake()
    {
        GetComponentInParent<Phase>().AddObjective(gameObject, HasMoved);
    }

    private void Update()
    {
        hasMoved = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D);
    }

    private bool HasMoved()
    {
        return hasMoved;
    }
}

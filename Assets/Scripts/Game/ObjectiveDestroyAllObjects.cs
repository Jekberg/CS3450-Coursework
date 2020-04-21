using UnityEngine;

public class ObjectiveDestroyAllObjects : MonoBehaviour {

    private void Awake()
    {
        GetComponentInParent<Phase>().AddObjective(gameObject, IsEverythinDestroyed);
    }

    private bool IsEverythinDestroyed()
    {
        return transform.childCount == 0;
    }
}

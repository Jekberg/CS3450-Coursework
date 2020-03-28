using UnityEngine;

public class RoundController : MonoBehaviour
{
    public bool IsCompleted()
    {
        return 0 == transform.childCount;
    }
}

using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject hudPrefab;

    public static GameObject Player {
        get;
        private set;
    }

    public void Awake()
    {
        Player = player;
        Cursor.lockState = CursorLockMode.Locked;
        Instantiate(hudPrefab);
    }
}

using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject hudPrefab;

    public static GameObject Player {
        get;
        private set;
    }

    public void Awake()
    {
        if(Player == null)
            Player = Instantiate(playerPrefab, transform);
        Cursor.lockState = CursorLockMode.Locked;
        Instantiate(hudPrefab);
    }
}

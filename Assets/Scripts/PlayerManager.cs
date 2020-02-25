using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    public static GameObject PlayerInstance {
        get;
        private set;
    }

    public void Awake()
    {
        if(PlayerInstance == null)
            PlayerInstance = Instantiate(playerPrefab, transform);
    }
}

using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField]
    private GameObject userInterface;

    void Awake ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Instantiate(userInterface);
    }
}

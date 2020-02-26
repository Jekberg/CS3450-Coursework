using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Current
    {
        get;
        private set;
    }

    [SerializeField]
    private GameObject menuPrefab;

    public void Awake()
    {
        Current = Instantiate(menuPrefab);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadSceneAsync("TestArea");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

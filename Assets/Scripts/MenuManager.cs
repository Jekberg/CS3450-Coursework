using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            QuitGame();
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("TestArea");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

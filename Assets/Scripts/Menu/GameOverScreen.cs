using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadSceneAsync(GlobalCache.Cache.Get<string>("Current Level"));
    }

    public void Quit()
    {
        SceneManager.LoadSceneAsync("Level Selector");
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

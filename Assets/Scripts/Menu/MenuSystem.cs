using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    private IDictionary<string, GameObject> menus = new Dictionary<string, GameObject>();
    private Stack<GameObject> activeCanvas = new Stack<GameObject>();

    public void Launch()
    {
        SceneManager.LoadSceneAsync("Level Selector");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NavigateTo(string name)
    {
        MenuManager.PushMenu(name);
    }
    
    public void NavigateBack()
    {
        MenuManager.PopMenu();
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Instance = new MenuManager();
        foreach (var menu in GetComponentsInChildren<MenuHook>(true))
            Register(menu.gameObject.name, menu);
        PushMenu(GetComponentsInChildren<MenuHook>(true).First().name);
    }
}

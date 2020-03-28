using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private IDictionary<string, GameObject> menus = new Dictionary<string, GameObject>();
    private Stack<GameObject> activeCanvas = new Stack<GameObject>();

    private MenuManager(){}

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Instance = new MenuManager();
        foreach (var menu in GetComponentsInChildren<MenuHook>(true))
            Register(menu.gameObject.name, menu);
        PushMenu(GetComponentsInChildren<MenuHook>(true).First().name);
    }

    public static MenuManager Instance
    {
        get;
        private set;
    }

    public static void Register(string name, MenuHook menu)
    {
        Debug.Log(string.Format("Regestering the {0} as {1}", menu, name));
        menu.gameObject.SetActive(false);
        Instance.menus.Add(name, menu.gameObject);
    }

    public static void Deregister(string name)
    {
        Instance.menus.Remove(name);
    }

    public static void PopMenu()
    {
        Instance.activeCanvas.Pop().gameObject.SetActive(false);
        if (Instance.activeCanvas.Any())
            Instance.activeCanvas.Peek().gameObject.SetActive(true);
        Debug.Log(string.Format("Menu depth is {0} after pop", Instance.activeCanvas.Count()));
    }

    public static void PushMenu(string name)
    {
        var menu = Instance.menus[name];
        menu.gameObject.SetActive(true);
        if (Instance.activeCanvas.Any())
            Instance.activeCanvas.Peek().gameObject.SetActive(false);
        Instance.activeCanvas.Push(menu);
        Debug.Log(string.Format("Menu depth is {0} after push", Instance.activeCanvas.Count()));
    }
}

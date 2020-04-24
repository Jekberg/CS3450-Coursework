using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    [SerializeField] private string menuItemTag;
    [SerializeField] private string selectSaveMenuName;
    private readonly IDictionary<string, GameObject> menus = new Dictionary<string, GameObject>();
    private readonly Stack<GameObject> activeCanvas = new Stack<GameObject>();

    public bool IsLoad
    {
        get;
        private set;
    }

    public void NavigateToSaveSelect(bool isLoad)
    {
        IsLoad = isLoad;
        NavigateTo(selectSaveMenuName);
    }

    public void StartGame(string saveFileName)
    {
        var dataRepo = GetComponent<DataRepository>();
        if (dataRepo == null)
            return;

        GlobalCache.Cache.Clear();
        GlobalCache.Cache.Set("Save File", string.Format("Assets/Saves/{0}", saveFileName));
        if (IsLoad)
            dataRepo.Load(GlobalCache.Cache.Get<string>("Save File"));
        else
            dataRepo.Save(GlobalCache.Cache.Get<string>("Save File"));
        SceneManager.LoadSceneAsync("Level Selector");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void NavigateBack()
    {
        activeCanvas.Pop().gameObject.SetActive(false);
        if (activeCanvas.Any())
            activeCanvas.Peek().gameObject.SetActive(true);
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;

        var i = 0;
        for(; i < transform.childCount; ++i)
            if(transform.GetChild(i).tag == menuItemTag)
            {
                Debug.Log(transform.GetChild(i).gameObject);
                transform.GetChild(i).gameObject.SetActive(true);
                activeCanvas.Push(transform.GetChild(i).gameObject);
                ++i;
                break;
            }

        for(; i < transform.childCount; ++i)
        {
            if (transform.GetChild(i).tag != menuItemTag)
                continue;
            transform.GetChild(i).gameObject.SetActive(false);
            menus[transform.GetChild(i).name] = transform.GetChild(i).gameObject;
        }
    }

    private void NavigateTo(string name)
    {
        var menu = menus[name];
        menu.gameObject.SetActive(true);
        if (activeCanvas.Any())
            activeCanvas.Peek().gameObject.SetActive(false);
        activeCanvas.Push(menu);
    }
}

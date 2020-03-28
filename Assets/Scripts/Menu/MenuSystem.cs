using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public void Launch()
    {
        SceneManager.LoadSceneAsync("Level 1");
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
}

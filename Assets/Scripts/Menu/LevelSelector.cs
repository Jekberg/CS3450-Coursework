using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Text scoreCounter;

    public void StartLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Start()
    {
        string totalScoreKey = "Total_Score";
        if (!GlobalCache.Cache.Contains(totalScoreKey))
            GlobalCache.Cache.Set(totalScoreKey, 0.0f);
        scoreCounter.text = string.Format("Score: {0}", GlobalCache.Cache.Get<float>(totalScoreKey));
    }
}

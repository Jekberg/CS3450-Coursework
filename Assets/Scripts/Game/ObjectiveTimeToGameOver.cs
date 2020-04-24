using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveTimeToGameOver : MonoBehaviour {
    [SerializeField] private float timeInSeconds = 10.0f;

    private void Awake()
    {
        GetComponentInParent<Phase>().AddObjective(gameObject, IsWaitCompleted);
    }

    private void Update()
    {
        if (timeInSeconds < 0)
            SceneManager.LoadSceneAsync("Game Over Screen");
        timeInSeconds -= Time.deltaTime;
    }

    private bool IsWaitCompleted()
    {
        return true;
    }
}

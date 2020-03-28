using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private ulong scoreCount = 0;    

    private ScoreCounter() {}

    public static ScoreCounter Instance {
        get;
        private set;
    }

    public void Increase(ulong amount)
    {
        scoreCount += amount;
    }

    private void Awake()
    {
        Instance = new ScoreCounter();
    }
}

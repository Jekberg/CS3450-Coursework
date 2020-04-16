using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    private LevelInfo(){ }

    public float PlayTime
    {
        get { return Time.timeSinceLevelLoad; }
    }

    public float ScoreCount
    {
        get;
        private set;
    }

    public static LevelInfo Info {
        get;
        private set;
    }

    public void IncreaseScore(float amount)
    {
        ScoreCount += amount;
    }

    private void Awake()
    {
        Info = new LevelInfo();
    }
}

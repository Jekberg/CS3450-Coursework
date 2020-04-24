using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameObject manager;
    [SerializeField] private GameObject rounds;

    public int CurrentRound
    {
        get;
        private set;
    }

    public int TotalRounds
    {
        get { return Phases.Count(); }
    }

    public float PlayTime
    {
        get { return Time.timeSinceLevelLoad; }
    }

    public float ScoreCount
    {
        get;
        private set;
    }

    public Phase Phase
    {
        get { return CurrentRound == -1 ? null : Phases[CurrentRound]; }
    }

    private Phase[] Phases
    {
        get { return rounds.GetComponentsInChildren<Phase>(true); }
    }

    public void IncreaseScore(float amount)
    {
        ScoreCount += amount;
    }

    private void Awake()
    {
        manager = gameObject;
        foreach (var round in Phases)
            round.gameObject.SetActive(false);
        Phases[CurrentRound].gameObject.SetActive(true);
    }

    private void Start()
    {
        GlobalCache.Cache.Set("Level Complete", false);
    }

    private void Update()
    {
        if (CurrentRound == -1)
            return;
        else if (Phases[CurrentRound].Completed)
        {
            if (CurrentRound < Phases.Count())
                Phases[CurrentRound++].gameObject.SetActive(false);
            if (CurrentRound < Phases.Count())
                Phases[CurrentRound].gameObject.SetActive(true);
            else if (CurrentRound == Phases.Count())
            {
                /* WIN */
                GlobalCache.Cache.Set("Level Complete", true);
                CurrentRound = -1;
                var totalScore = GlobalCache.Cache.GetOrDefault<float>("Total_Score");
                GlobalCache.Cache.Set("Total_Score", totalScore + GameManager.Manager.ScoreCount);
                SceneManager.LoadSceneAsync("Victory Screen");
            }
        }
    }

    public static GameManager Manager
    {
        get { return manager.GetComponent<GameManager>(); }
    }
}

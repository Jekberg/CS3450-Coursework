using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int currentRound = 0;
    private RoundController[] Rounds { get { return GetComponentsInChildren<RoundController>(true); } }    

    private void Awake()
    {
        foreach (var round in Rounds)
            round.gameObject.SetActive(false);
        Rounds[currentRound].gameObject.SetActive(true);
        Debug.Log(Rounds.Count());
    }

    private void Update()
    {
        if (!GetComponentsInChildren<PortalController>().Any()
                && !GetComponentsInChildren<EnemyController>().Any())
            NextPhase();
    }

    private void NextPhase()
    {
        if (currentRound < Rounds.Count())
            Rounds[currentRound++].gameObject.SetActive(false);
        if (currentRound < Rounds.Count())
            Rounds[currentRound].gameObject.SetActive(true);
        else
            /* WIN */
            SceneManager.LoadSceneAsync("Main Menu");
    }
}

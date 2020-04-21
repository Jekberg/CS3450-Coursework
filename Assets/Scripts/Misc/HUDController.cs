using System;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text scoreCounter;
    [SerializeField] private Text timeCounter;
    [SerializeField] private Text progressCounter;
    [SerializeField] private Text objectiveList;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image chargeBar;
    [SerializeField] private GameObject playPanel;
    [SerializeField] private GameObject pausePanel;
    private bool isPaused = false;

    public void Resume()
    {
        Debug.Log("The game is resumed...");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
        playPanel.SetActive(true);   
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Return()
    {
        string returnTo = "Level Selector";
        Debug.Log(string.Format("Returning to {0}", returnTo));
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync(returnTo);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerController.Player.Health.onHealthUpdate += HandleHealthUpdate;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (isPaused)
                Resume();
            else
                Pause();
            
        var now = TimeSpan.FromSeconds(GameManager.Manager.PlayTime);
        scoreCounter.text = string.Format("Score: {0}", GameManager.Manager.ScoreCount);
        timeCounter.text = string.Format("Time: {0}:{1}:{2}.{3}", now.Hours, now.Minutes, now.Seconds, now.Milliseconds);
        progressCounter.text = GameManager.Manager.CurrentRound != -1
            ? string.Format("Progress: {0}/{1}", GameManager.Manager.CurrentRound, GameManager.Manager.TotalRounds)
            : "";

        var currentPhase = GameManager.Manager.Phase;
        objectiveList.text = currentPhase != null
            ? objectiveList.text = currentPhase.ToComplete
                .Select(objective => objective.name)
                .Aggregate(new StringBuilder(), (xs, x) => xs.Append(" - ").Append(x).Append("\n"))
                .ToString()
            : "";

        chargeBar.fillAmount = PlayerController.Player.DashCharge;
    }

    private void HandleHealthUpdate(float health)
    {
        healthBar.fillAmount = health;
    }


    private void Pause()
    {
        Debug.Log("The game is paused...");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
        playPanel.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
}

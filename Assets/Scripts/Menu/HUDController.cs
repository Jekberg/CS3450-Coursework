using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text scoreCounter;
    [SerializeField] private Text timeCounter;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image chargeBar;

    private HUDController() { }

    public static HUDController Controller
    {
        get;
        private set;
    }

    private void Awake()
    {
        Controller = new HUDController();
    }

    private void Start()
    {
        PlayerController.Player.Health.onHealthUpdate += HandleHealthUpdate;
    }

    private void Update()
    {
        var now = TimeSpan.FromSeconds(LevelInfo.Info.PlayTime);
        scoreCounter.text = string.Format("Score: {0}", LevelInfo.Info.ScoreCount);
        timeCounter.text = string.Format("Time: {0}:{1}:{2}.{3}", now.Hours, now.Minutes, now.Seconds, now.Milliseconds);
        chargeBar.fillAmount = PlayerController.Player.DashCharge;
    }

    private void HandleHealthUpdate(float health)
    {
        healthBar.fillAmount = health;
    }
}

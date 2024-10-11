using UnityEngine;
using UnityEngine.UI;

//Devin, 2024/03/02
//Deals with the timer and killing the player when the time runs out. It also handles moving the player on death top the loss screen and ending the game
public class GameManager : MonoBehaviour
{
    public float timerDuration = 100f; // Duration of the timer in seconds
    private float timer;
    private bool isTimerRunning = false;

    public Text timerText; // Reference to UI Text for timer display
    public PlayerController playerController; // Reference to PlayerController script

    void Start()
    {
        timer = timerDuration;
        isTimerRunning = true;
        UpdateTimerUI();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                isTimerRunning = false;
                if (playerController != null)
                {
                    playerController.TakeDamage(playerController.GetCurrentLives()); // Lose all lives
                }
            }
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.FloorToInt(timer / 60f).ToString("00") + ":" + Mathf.FloorToInt(timer % 60f).ToString("00");
        }
    }
}

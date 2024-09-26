using UnityEngine;
using UnityEngine.UI;

//Devin, 2024/03/02
/// <summary>
// handles lives and checks the player lives
/// </summary>

public class LivesCounter : MonoBehaviour
{
    public PlayerController playerController; // Reference to the PlayerController script
    private Text livesText;

    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateLivesCounter();
    }

    void Update()
    {
        UpdateLivesCounter();
    }

    void UpdateLivesCounter()
    {
        if (playerController != null)
        {
            livesText.text = "Lives: " + playerController.GetCurrentLives().ToString();
        }
    }
}

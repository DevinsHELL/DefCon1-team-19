using UnityEngine;
using UnityEngine.SceneManagement;

//Devin, 2024/03/02
//Handles end game by detecting a player collision and sending the player to the "you win" screen
public class Flagpole : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //Compares to the player by referencing the tag
        {
            SceneManager.LoadScene("YouWin"); // Load the "YouWin" scene
        }
    }
}

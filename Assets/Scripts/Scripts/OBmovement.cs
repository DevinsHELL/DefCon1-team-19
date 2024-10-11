using System;
using UnityEngine;
// add randomized movement to the spikes that as long as the player is alive, every 2 secounds the will increa there movement speed and time between movements slightly

public class Mover : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public PlayerController pc;
    public static int currentLives = 3; //redundant lives counter
    

    void Start()
    {
        
        // using a built in unity function that will call Changedircetion repeatedly 
        pc = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("ChangeDirection", 0, 3f); // Change direction every 2 seconds
    }
    private void Update()
    {
        Debug.Log("Player's current lives: " + currentLives);
        if (currentLives > 0)
        {
            moveSpeed = moveSpeed + 0.001f;
            WaitForSeconds waitForSeconds = new WaitForSeconds(3f);
        }

        if (moveSpeed > 18)
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(1.5f);
            moveSpeed = 5;
            currentLives = currentLives - 1;
        }
       // adds a cycle which limits the movement speed increase once the speed reaches 18 using a internal "lives" counter that is seperate from the player
       // I found that the longer i let the speed of the enemy increase the more sparaticly the movement shifts become. This lead to the enemy either flying across the map or flippinf itself upside down
    }
    void ChangeDirection()
    {
        // Randomize movement direction
        Vector2 randomDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        rb.velocity = randomDirection * moveSpeed;

    }
    public static int GetCurrentLives()
    {
        return currentLives;
        
    }
}

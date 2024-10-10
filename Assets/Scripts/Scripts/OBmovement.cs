using System;
using UnityEngine;
// add randomized movement to the spikes that as long as the player is alive, every 2 secounds the will increa there movement speed and time between movements slightly

public class Mover : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public PlayerController pc;
    public static int currentLives = 3;
    

    void Start()
    {
        
        // using a built in unity function that will call Changedircetion repeatedly 
        pc = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("ChangeDirection", 0, 2f); // Change direction every 2 seconds
    }
    private void Update()
    {
        Debug.Log("Player's current lives: " + currentLives);
        if (currentLives > 0)
        {
            moveSpeed = moveSpeed + 0.01f;
            WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
        }
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

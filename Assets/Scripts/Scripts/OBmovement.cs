using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        // using a built in unity function that will call Changedircetion repeatedly 
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("ChangeDirection", 0, 2f); // Change direction every 2 seconds
    }

    void ChangeDirection()
    {
        // Randomize movement direction
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.velocity = randomDirection * moveSpeed;
    }
}

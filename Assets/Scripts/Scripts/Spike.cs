using UnityEngine;

//Devin, 2024/03/02
//Spikes that deal damage to the player. The check for a collision the deal 1 damage to the player when hit. Has a 1 sec cooldown and also pushes the player away from the spike after a collsion 
public class Spike : MonoBehaviour
{
    public int damage = 1;
    public float bounceForce = 10f;
    public float bounceBackForce = 5f;
    public float cooldownTime = 1f; // Cooldown time in seconds
    private bool canBounce = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canBounce)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage); // Take away a life from the player
                Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
                if (playerRb != null)
                {
                    Vector2 bounceDirection = (playerRb.position - (Vector2)transform.position).normalized;
                    playerRb.velocity = Vector2.up * bounceForce + -bounceDirection * bounceBackForce;
                    canBounce = false; // Set canBounce to false to prevent multiple bounces
                    Invoke("ResetBounce", cooldownTime); // Invoke ResetBounce after cooldownTime
                }
            }
        }
    }

    void ResetBounce()
    {
        canBounce = true; // Reset canBounce to true after cooldown
    }
}
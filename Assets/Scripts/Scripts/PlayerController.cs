using UnityEngine;
using System.Collections;

//Devin, 2024/03/02
//Handles all player movement as well as checking when the player lives reach zero. 
//It also preforms checks on the player currnet lives as well as taking acre of the detecting the player death and sending them to the you lose scene ending the game.
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxHealth = 3;
    private int currentHealth;
    private Rigidbody2D rb;

    // *** New Dash Feature Variables ***
    public float dashSpeed = 8f; // Speed during dash
    public float dashTime = 0.2f; // Duration of the dash
    private bool isDashing = false; // Is the player dashing?
    private bool canDash = true; // Can the player dash?
    private float dashCooldown = 1f; // Time before dash is available again


    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }


        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f) * moveSpeed;
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // *** Dash Input ***
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    void Jump() //Claculates player jump
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // *** New Dash Function ***
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0; // Disable gravity during dash


        Vector2 dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;

        moveSpeed = 0;

        dashSpeed = 20;

        rb.velocity = dashDirection * dashSpeed;

        tr.emitting = true;

        yield return new WaitForSeconds(dashTime);

        moveSpeed = 8; dashSpeed = 0;

        tr.emitting = false;

        rb.velocity = new Vector2(0, rb.velocity.y); // Stop horizontal movement after dash
        rb.gravityScale = originalGravity; // Restore gravity

        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) //references the players health and checks if it is less then or equal to zero
        {
            Die();
        }
    }

    void Die() // on death sends player to the you lose screen
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("YouLose");
    }

    public int GetCurrentLives()
    {
        return currentHealth;
    }

 
}
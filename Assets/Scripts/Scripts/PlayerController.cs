using UnityEngine;

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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0f) * moveSpeed;
        rb.velocity = new Vector2(movement.x, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump() //Claculates player jump
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
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
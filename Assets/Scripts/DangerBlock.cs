using UnityEngine;

public class DangerBlock : MonoBehaviour
{
    public float invincibilityDuration = 3f; // Duration of invincibility after taking damage
    private bool isInvincible = false; // Flag to track if Clio is currently invincible
    private float invincibilityTimer = 0f; // Timer to track remaining invincibility time

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isInvincible)
        {
            // Remove a life from Clio
            ClioLives clioLives = collision.gameObject.GetComponent<ClioLives>();
            if (clioLives != null)
            {
                clioLives.RemoveLife();

                // Trigger invincibility
                StartInvincibility(collision.gameObject);
            }
        }
    }

    private void Update()
    {
        // Update invincibility timer
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0)
            {
                isInvincible = false;
                // Optionally, reset Clio's visibility here
                // For example, you could set Clio's sprite renderer to visible
            }
        }
    }

    private void StartInvincibility(GameObject clio)
    {
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;

        // Optionally, modify Clio's visibility to indicate invincibility
        // For example, you could set Clio's sprite renderer to invisible
        // clio.GetComponent<SpriteRenderer>().enabled = false;

        // Add visual feedback for invincibility (such as flashing)
        // You can implement this using coroutine or other methods
        // For simplicity, we'll just log a message here
        Debug.Log("Clio is invincible!");
    }
}

using UnityEngine;

public class DangerBlock : MonoBehaviour
{
    public float invincibilityDuration = 3f; 
    private bool isInvincible = false; 
    private float invincibilityTimer = 0f; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isInvincible)
        {
            ClioLives clioLives = collision.gameObject.GetComponent<ClioLives>();
            if (clioLives != null)
            {
                clioLives.RemoveLife();

                StartInvincibility(collision.gameObject);
            }
        }
    }

    private void Update()
    {
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }

    private void StartInvincibility(GameObject clio)
    {
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;

        Debug.Log("Clio is invincible!");
    }
}

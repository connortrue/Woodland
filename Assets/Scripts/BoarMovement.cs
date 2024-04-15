using UnityEngine;

public class BoarMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private SpriteRenderer spriteRenderer;

    public float moveSpeed = 3f;
    public LayerMask groundLayer;

    private bool facingLeft = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (IsVisibleOnScreen())
        {
            Move();
        }
    }

    private void Move()
    {
        if (facingLeft)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
    }

    private bool IsVisibleOnScreen()
    {
        Transform spriteTransform = transform.Find("sprite");
        if (spriteTransform != null)
        {
            Renderer renderer = spriteTransform.GetComponent<Renderer>();
            if (renderer != null)
            {
                bool isVisible = renderer.isVisible;
                return isVisible;
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            // ...
        }
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}

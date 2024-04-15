using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Camera camera;
    private new Rigidbody2D rigidbody;

    private Vector2 velocity;
    private float inputAxis;

    public float moveSpeed = 8f;
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);

    public bool grounded { get; private set; }
    public bool jumping { get; private set; }
    public bool running => Mathf.Abs(velocity.x) > 0.25f || Mathf.Abs(inputAxis) > 0.25f;
    public bool attacking { get; private set; }
    public bool killed { get; private set; }
    private int lives = 3;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BoarBottom")) // Check collision with Boar's bottom hit box
        {
            lives--; // Deduct one life
            Debug.Log("Lives remaining: " + lives);
            if (lives <= 0)
            {
                GameManager.Instance.ResetLevel(); // Reset the level if lives are zero or less
                Debug.Log("Game Over!");
            }
        }
        else if (collision.gameObject.CompareTag("BoarTop")) // Check collision with Boar's top hit box
        {
            Destroy(collision.gameObject.transform.parent.gameObject); // Destroy the Boar GameObject
        }
    }

    private void Update()
    {
        HorizontalMovement();
     
        grounded = rigidbody.Raycast(Vector2.down);

        if (grounded) {
            GroundedMovement();
        }
        
        ApplyGravity();
        // Debug.Log("Grounded: " + grounded);

    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        if (Mathf.Abs(inputAxis) > 0.1f)
        {
            velocity.x = inputAxis * moveSpeed;
        }
        else
        {
            velocity.x = 0f;
        }
        if (velocity.x > 0f) {
            transform.eulerAngles = Vector3.zero;
        }   else if (velocity.x < 0f) {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

    }
    
    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0f;


        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
            jumping = true;
        }
    }

    private void ApplyGravity()
    {
        if (!grounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;

        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 1f, rightEdge.x - 1f);

        rigidbody.MovePosition(position);
    }
}
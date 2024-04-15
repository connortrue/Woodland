using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerMovement movement;

    public Sprite idle;
    public AnimatedSprite jump;
    public AnimatedSprite run;

    public Sprite dead;
    public Sprite attack;

    private void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>(); 
       movement = GetComponentInParent<PlayerMovement>();
    }
    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }
    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void LateUpdate()
    {
        jump.enabled = movement.jumping;
        run.enabled = movement.running;

        if (movement.jumping) {
            spriteRenderer.sprite = jump.GetCurrentSprite();
        }
            else if (movement.killed) {
            spriteRenderer.sprite = dead;
        }   else if (movement.attacking) {
            spriteRenderer.sprite = attack;
        }   else if (!movement.running) {
            spriteRenderer.sprite = idle;
        }
    }
}
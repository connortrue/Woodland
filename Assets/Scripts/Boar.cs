using UnityEngine;

public class Boar : MonoBehaviour
{
    public Sprite deadBoar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.down))
            {
                Kill();
            }
        }
    }

    private void Kill()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = deadBoar;
        Destroy(gameObject, 0.5f);
    }
}

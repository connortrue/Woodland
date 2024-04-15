using UnityEngine;

public class Killbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ClioLives clioLives = collision.GetComponent<ClioLives>();
            if (clioLives != null)
            {
                clioLives.RemoveAllLives();
            }

    
            GameManager.Instance.ResetLevel();
        }
    }
}

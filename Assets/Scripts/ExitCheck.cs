using UnityEngine;

public class ExitCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player collided with exit");

            if (GameManager.Instance.coinsCollected >= GameManager.Instance.totalCoinsInLevel)
            {
                Debug.Log("All coins collected. Resetting the level...");
                GameManager.Instance.ResetLevel();
            }
            else
            {
                Debug.Log("Not all coins collected");
            }
        }
    }
}

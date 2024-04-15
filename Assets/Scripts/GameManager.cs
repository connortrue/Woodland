using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string stage { get; private set; }
    public int lives { get; private set; }
    public int coinsCollected { get; private set; }
    public int totalCoinsInLevel = 3;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        coinsCollected = 0;
        LoadLevel("Woodland-1");
        // UpdateHeartDisplay();
    }

    private void LoadLevel(string stage)
    {
        this.stage = stage;
        SceneManager.LoadScene("Woodland-1");
    }

    public void NextLevel()
    {
        // ... LoadLevel(stage + 1)
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        else
        {
            LoadLevel(stage);
        }
        // UpdateHeartDisplay();
    }

    private void GameOver()
    {
        NewGame();
    }

    public void CollectCoin()
    {
        coinsCollected++;
        if (coinsCollected >= totalCoinsInLevel)
        {
             Debug.Log("All coins collected!");
        }
    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        // UpdateHeartDisplay();
    }
    
}

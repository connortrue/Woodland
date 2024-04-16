using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int lives { get; private set; }
    public int coinsCollected { get; private set; }
    public int totalCoinsInLevel = 3;

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
        StartGame();
    }

    private void StartGame()
    {
        lives = 3;
        coinsCollected = 0;
        LoadLevel("StartScene");
    }

    private void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlayerDies()
    {
        lives--;
        if (lives <= 0)
        {
            LoadLevel("DeathScene");
        }
        else
        {
            LoadLevel("BrokeScene");
        }
    }

    public void PlayerPassesExitCheck()
    {
        if (coinsCollected >= totalCoinsInLevel)
        {
            LoadLevel("RealityScene");
        }
        else
        {
            LoadLevel("BrokeScene");
        }
    }

    public void ReturnToMainMenu()
    {
        LoadLevel("MainMenu");
    }

    public void CollectCoin()
    {
        coinsCollected++;
        if (coinsCollected >= totalCoinsInLevel)
        {
            Debug.Log("All coins collected!");
        }
    }
}

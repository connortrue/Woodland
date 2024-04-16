using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string stage { get; private set; }
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
        NewGame();
    }

    private void NewGame()
    {
        coinsCollected = 0;
        LoadLevel("Woodland-1");
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

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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

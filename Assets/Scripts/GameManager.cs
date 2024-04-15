using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }
    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        }   else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (Instance == this) {
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

        LoadLevel();
    }

    private void LoadLevel(int stage)
    {
        this.stage = stage;

        SceneManager.LoadScene($"{stage}");
    }

    public void NextLevel()
    {
        // ... LoadLevel(stage + 1);
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0) {
            LoadLevel(stage);
        } else {
            GameOver();
        }
    }

    private void GameOver()
    {
        NewGame();
        // SceneManager.LoadScene("GameOver")
    }

}

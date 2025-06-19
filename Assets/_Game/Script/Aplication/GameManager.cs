using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameState currentState = GameState.MainMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GoToMainMenu();
    }

    public void GoToMainMenu()
    {
        currentState = GameState.MainMenu;

        SceneManager.LoadScene("Main_Menu");
        AudioManager.instance.Play("MainMenuMusic");
    }

    public void LoadGame()
    {
        currentState = GameState.Loading;

        LoadLoadingScene();
    }

    private void LoadLoadingScene()
    {
        SceneManager.LoadScene("Main_Loading");
    }

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Main_Gameplay");
       
        StartGame();
    }

    public void StartGame()
    {
        currentState = GameState.InGame;

        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (currentState != GameState.InGame) return;

        currentState = GameState.Paused;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        if (currentState != GameState.Paused) return;

        currentState = GameState.InGame;
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        LoadGameplayScene();
    }

    public void OnPlayerDeath()
    {
        PauseGame();
        Debug.Log("Player Died");
        UIManager.Instance.OpenDeathUI();
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        Time.timeScale = 0f;
        Debug.Log("Game Over");
        UIManager.Instance.OpenGameOverUI();


    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public GameState GetCurrentState()
    {
        return currentState;
    }
}

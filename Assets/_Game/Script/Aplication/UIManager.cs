using UnityEngine;

/// <summary>
/// Mengurus tampilan UI atau game object secara terpusat
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    //UI GameOver
    [Header("UI Game Over")]
    public GameObject gameOverUI;
    public GameObject deathUI;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Mengaktifkan sebuah game object
    /// </summary>
    public void EnableTarget(GameObject target)
    {
        if (target != null && !target.activeSelf)
        {
            target.SetActive(true);
        }
    }

    /// <summary>
    /// Menonaktifkan sebuah game object
    /// </summary>
    public void DisableTarget(GameObject target)
    {
        if (target != null && target.activeSelf)
        {
            target.SetActive(false);
        }
    }

    //instantite UI GameOver and Parent to Object Canvas
    public void OpenGameOverUI()
    {
        if (gameOverUI != null)
        {
            GameObject uiInstance = Instantiate(gameOverUI);
            uiInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
            EnableTarget(uiInstance);
        }
    }
    public void OpenDeathUI()
    {
        if (deathUI != null)
        {
            GameObject uiInstance = Instantiate(deathUI);
            uiInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
            EnableTarget(uiInstance);
        }
    }

    //close UI GameOver and Death
    public void CloseGameOverUI()
    {
        Destroy(gameOverUI);
    }
    public void CloseDeathUI()
    {
        Destroy(deathUI);
        PlayerDeath playerDeath = FindFirstObjectByType<PlayerDeath>();
        if (playerDeath != null)
        {
            playerDeath.ReturnToSpawn();
        }
    }
}

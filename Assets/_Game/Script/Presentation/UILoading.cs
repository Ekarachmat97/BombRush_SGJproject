using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class UILoading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private Slider progressBar;

    private bool isReadyToActivate = false;

    private void Start()
    {
        if (loadingText != null)
            loadingText.text = "Loading...";

        if (progressBar != null)
        {
            progressBar.value = 0f;
            progressBar.maxValue = 1f;
        }

        StartCoroutine(LoadGameAsync());
    }

    private IEnumerator LoadGameAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main_Gameplay");
        if (asyncLoad == null)
        {
            Debug.LogError("Failed to load scene 'Main_Gameplay'.");
            yield break;
        }

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            // Normalisasi progress dari 0 ke 1
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            if (progressBar != null)
                progressBar.value = progress;

            // Update loading text
            if (!isReadyToActivate)
            {
                if (loadingText != null)
                    loadingText.text = $"Loading... {progress * 100f:0}%";
            }

            // Saat progress sudah penuh (100%)
            if (progress >= 1f && !isReadyToActivate)
            {
                isReadyToActivate = true;

                if (loadingText != null)
                    loadingText.text = "Press any key to continue...";
            }

            // Tunggu input
            if (isReadyToActivate && Input.anyKeyDown)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}

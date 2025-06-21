using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public float coldownTime = 3f;  
    public TextMeshProUGUI timerText;

    private float timer;
    private bool isCountingDown = false;

    void OnEnable()
    {
        // Mulai countdown saat UI aktif
        timer = coldownTime;
        isCountingDown = true;
        if (timerText != null)
            timerText.text = timer.ToString("F2");
    }

    void Update()
    {
        if (!isCountingDown) return;

        timer -= Time.deltaTime;
        if (timer < 0f) timer = 0f;

        if (timerText != null)
            timerText.text = timer.ToString("F2");

        if (timer <= 0f)
        {
            isCountingDown = false;
            GameManager.Instance.GoToMainMenu();
            GameManager.Instance.ResumeGame();
        }
    }
}
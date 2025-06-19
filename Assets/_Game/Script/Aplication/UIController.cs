using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [Header("Currency UI")]
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI gemsText;

    [Header("Experience UI")]
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI expText;
    [SerializeField] private Slider expSlider;

    [Header("Settings")]
    [SerializeField] private Slider volumeSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Volume setting
        if (volumeSlider != null)
        {
            float savedVolume = SaveLoadManager.Instance?.LoadVolume() ?? 1f;
            volumeSlider.value = savedVolume;
            AudioManager.instance?.SetVolume(savedVolume);
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

        // Subscribe to currency event
        if (CurrencyManager.Instance != null)
        {
            CurrencyManager.Instance.OnCurrencyChanged += UpdateUI;
            UpdateUI();
        }

        
    }

    private void OnDestroy()
    {
        if (CurrencyManager.Instance != null)
            CurrencyManager.Instance.OnCurrencyChanged -= UpdateUI;
    }

    public void UpdateUI()
    {
        var cm = CurrencyManager.Instance;
        if (cm == null) return;

        coinsText.text = cm.GetCoins().ToString();
        gemsText.text = cm.GetGems().ToString();

        int exp = cm.GetExp();
        int expNeeded = cm.GetExpNeeded();

        levelText.text = $"Level {cm.GetLevel()}";
        expText.text = $"{exp} / {expNeeded}";

        if (expSlider != null)
        {
            expSlider.maxValue = expNeeded;
            expSlider.value = exp;
        }
    }

    private void OnVolumeChanged(float value)
    {
        AudioManager.instance?.SetVolume(value);
        SaveLoadManager.Instance?.SaveVolume(value);
    }

    public void OnClickStartGame()
    {
        GameManager.Instance?.LoadGame();
    }
}

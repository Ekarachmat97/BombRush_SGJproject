using UnityEngine;

/// <summary>
/// Mengurus menyimpan dan mengambil data Currency dari PlayerPrefs
/// </summary>
public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private const string COINS_KEY = "COINS";
    private const string GEMS_KEY = "GEMS";
    private const string EXP_KEY = "EXP";
    private const string LEVEL_KEY = "LEVEL";

    //volume key
    private const string VOLUME_KEY = "Volume";

    public void SaveCurrency()
    {
        var cm = CurrencyManager.Instance;
        if (cm == null) return;

        PlayerPrefs.SetInt(COINS_KEY, cm.GetCoins());
        PlayerPrefs.SetInt(GEMS_KEY, cm.GetGems());
        PlayerPrefs.SetInt(EXP_KEY, cm.GetExp());
        PlayerPrefs.SetInt(LEVEL_KEY, cm.GetLevel());
        PlayerPrefs.Save();
    }


    public void LoadCurrency()
    {
        var cm = CurrencyManager.Instance;
        if (cm == null) return;

        cm.coins = PlayerPrefs.GetInt(COINS_KEY, 0);
        cm.gems = PlayerPrefs.GetInt(GEMS_KEY, 0);
        cm.exp = PlayerPrefs.GetInt(EXP_KEY, 0);
        cm.level = PlayerPrefs.GetInt(LEVEL_KEY, 1);
    }

    // Save volume setting
    public void SaveVolume(float volume)
    {
        PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }
    // Load volume setting
    public float LoadVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY, 1f); 
    }
}
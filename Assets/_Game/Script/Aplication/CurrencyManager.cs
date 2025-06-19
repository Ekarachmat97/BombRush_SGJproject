using UnityEngine;
using System;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }

    public int coins;
    public int gems;
    public int exp;
    public int level = 1;

    public event Action OnCurrencyChanged;

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

    void Start()
    {
        //load currency from PlayerPrefs
        SaveLoadManager.Instance?.LoadCurrency();
        OnCurrencyChanged?.Invoke();
    }

    public void AddCoins(int amount)
    {
        if (amount <= 0) return;
        coins += amount;
        OnCurrencyChanged?.Invoke();
        //save currency after adding coins
        SaveLoadManager.Instance?.SaveCurrency();
    }

    public bool SpendCoins(int amount)
    {
        if (amount <= 0 || coins < amount) return false;
        coins -= amount;
        OnCurrencyChanged?.Invoke();
        SaveLoadManager.Instance?.SaveCurrency();
        return true;   
    }

    public void AddGems(int amount)
    {
        if (amount <= 0) return;
        gems += amount;
        OnCurrencyChanged?.Invoke();
        SaveLoadManager.Instance?.SaveCurrency();
    }

    public bool SpendGems(int amount)
    {
        if (amount <= 0 || gems < amount) return false;
        gems -= amount;
        OnCurrencyChanged?.Invoke();
        SaveLoadManager.Instance?.SaveCurrency();
        return true;
    }

    public void AddExp(int amount)
    {
        if (amount <= 0) return;

        exp += amount;
        int expNeeded = GetExpNeeded();
        while (exp >= expNeeded)
        {
            exp -= expNeeded;
            level++;
            expNeeded = GetExpNeeded();
        }
        OnCurrencyChanged?.Invoke();
        SaveLoadManager.Instance?.SaveCurrency();
    }

    // Getters
    public int GetCoins() => coins;
    public int GetGems() => gems;
    public int GetExp() => exp;
    public int GetLevel() => level;

    public int GetExpNeeded() => level * 100;
}

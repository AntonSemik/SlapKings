using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameState : MonoBehaviour
{
    public static SaveGameState _inst;

    public int _level{ private set; get;}
    public int _healthLevel { private set; get; }
    public int _attackLevel { private set; get; }
    public int _coins { private set; get; }


    private void Awake()
    {
        _inst = this;

        LoadPlayerStats();
    }

    void LoadPlayerStats()
    {
        _level = PlayerPrefs.GetInt("Level", 1);

        _healthLevel = PlayerPrefs.GetInt("HealthLevel", 1);
        _attackLevel = PlayerPrefs.GetInt("AttackLevel", 1);

        _coins = PlayerPrefs.GetInt("Coins", 0);

    }

    public void SaveInt(string _key, int _value)
    {
        PlayerPrefs.SetInt(_key, _value);
    }

    public void SavePlayerStats()
    {
        PlayerPrefs.SetInt("Level", _level);

        PlayerPrefs.SetInt("HealthLevel", _healthLevel);
        PlayerPrefs.SetInt("AttackLevel", _attackLevel);

        PlayerPrefs.SetInt("Coins", _coins);

    }

    private void OnApplicationPause()
    {
        SavePlayerStats();
    }
}

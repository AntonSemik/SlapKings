using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameState : MonoBehaviour
{
    public static SaveGameState _inst;

    public int _level, _healthLevel, _attackLevel, _coins;


    private void Awake()
    {
        _inst = this;

        LoadPlayerStat();
    }

    public void LoadPlayerStats()
    {
        _level = PlayerPrefs.GetInt("Level", 1);

        _healthLevel = PlayerPrefs.GetInt("HealthLevel", 1);
        _attackLevel = PlayerPrefs.GetInt("AttackLevel", 1);

        _coins = PlayerPrefs.GetInt("Coins", 0);

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

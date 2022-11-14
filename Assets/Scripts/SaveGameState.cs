using UnityEngine;

public class SaveGameState : MonoBehaviour
{
    public int _level{ private set; get;}
    public int _healthLevel { private set; get; }
    public int _attackLevel { private set; get; }
    public int _coins { private set; get; }

    public bool _adsActive = true;
    public bool _soundsPaused = true;
    public bool _vibroOff = true;

    private void Awake()
    {   PlayerPrefs.SetInt("Level", 1);
        LoadPlayerStats();
    }

    void LoadPlayerStats()
    {
        _level = PlayerPrefs.GetInt("Level", 1);

        _healthLevel = PlayerPrefs.GetInt("HealthLevel", 1);
        _attackLevel = PlayerPrefs.GetInt("AttackLevel", 1);

        _coins = PlayerPrefs.GetInt("Coins", 0);

        _soundsPaused = PlayerPrefs.GetInt("SoundsPaused") != 0;
        _vibroOff = PlayerPrefs.GetInt("VibroOff") != 0;
        _adsActive = PlayerPrefs.GetInt("AdsActive") != 0;
    }

    public void SaveInt(string _key, int _value)
    {
        PlayerPrefs.SetInt(_key, _value);
    }
}
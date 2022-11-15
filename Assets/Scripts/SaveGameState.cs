using UnityEngine;

public class SaveGameState : MonoBehaviour
{
    public int _level => PlayerPrefs.GetInt("Level", 1);
    public int _healthLevel => PlayerPrefs.GetInt("HealthLevel", 1);
    public int _attackLevel => PlayerPrefs.GetInt("AttackLevel", 1);
    public int _coins => PlayerPrefs.GetInt("Coins", 0);

    public bool _adsActive = true;
    public bool _soundsPaused = true;
    public bool _vibroOff = true;

    private void Awake()
    {
        PlayerPrefs.SetInt("Level", 3); 
        LoadPlayerStats();
    }

    void LoadPlayerStats()
    {
        _soundsPaused = PlayerPrefs.GetInt("SoundsPaused") != 0;
        _vibroOff = PlayerPrefs.GetInt("VibroOff") != 0;
        _adsActive = PlayerPrefs.GetInt("AdsActive") != 0;
    }

    public void SaveInt(string _key, int _value)
    {
        PlayerPrefs.SetInt(_key, _value);
    }
}
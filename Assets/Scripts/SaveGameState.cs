using UnityEngine;

public class SaveGameState : MonoBehaviour
{
    public int _level => PlayerPrefs.GetInt("Level", 1);
    public int _healthLevel => PlayerPrefs.GetInt("HealthLevel", 1);
    public int _attackLevel => PlayerPrefs.GetInt("AttackLevel", 1);
    public int _coins => PlayerPrefs.GetInt("Coins", 0);

    public bool _adsActive => PlayerPrefs.GetInt("AdsActive", 1) != 0;
    public bool _soundsPaused => PlayerPrefs.GetInt("SoundsPaused", 0) != 0;
    public bool _vibroOff => PlayerPrefs.GetInt("VibroOff", 0) != 0;

    public void SaveInt(string _key, int _value)
    {
        PlayerPrefs.SetInt(_key, _value);
    }
}
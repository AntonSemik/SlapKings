using UI;
using UnityEngine;

public class SaveGameState : MonoBehaviour
{
    public int _totalLevel => PlayerPrefs.GetInt("TotalLevel", 1);
    public int _locationID => PlayerPrefs.GetInt("LocationID", 0);
    public int _currentLevel => PlayerPrefs.GetInt("CurrentLevel", 0);

    public int _healthLevel => PlayerPrefs.GetInt("HealthLevel", 1);
    public int _attackLevel => PlayerPrefs.GetInt("AttackLevel", 1);
    public int _coins => PlayerPrefs.GetInt("Coins", 0);
    public int _playerSkinID => PlayerPrefs.GetInt("PlayerSkinID", 0);

    public bool _adsActive => PlayerPrefs.GetInt("AdsActive", 1) != 0;
    public bool _soundsPaused => PlayerPrefs.GetInt("SoundsPaused", 0) != 0;
    public bool _vibroOff => PlayerPrefs.GetInt("VibroOff", 0) != 0;
    
    public ThemeManager.GameThemes GameThemeUI => (ThemeManager.GameThemes) PlayerPrefs.GetInt(ThemeUI, 0);

    private const string ThemeUI = "ThemeUI";

    public void SaveInt(string _key, int _value)
    {
        PlayerPrefs.SetInt(_key, _value);
    }
    
    public void SaveTheme(ThemeManager.GameThemes gameTheme)
    {
        PlayerPrefs.SetInt(ThemeUI, (int) gameTheme);
    }
}
using UI;
using UnityEngine;

public class SaveGameState : MonoBehaviour
{
    public int _totalLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.TotalLevelKey, 1);
    public int _locationID => PlayerPrefs.GetInt(PlayerPrefsKeys.LocationIDKey, 0);
    public int _currentLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevelKey, 0);

    public int _healthLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.HealthLevelKey, 1);
    public int _attackLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.DamageLevelKey, 1);
    public int _coins => PlayerPrefs.GetInt(PlayerPrefsKeys.CoinsKey, 0);
    public int _playerSkinID => PlayerPrefs.GetInt(PlayerPrefsKeys.PlayerSkinID, 0);
    public int _playerMegaslapSkinID => PlayerPrefs.GetInt(PlayerPrefsKeys.PlayerMegaslapSkinID, 0);

    public bool _adsActive => PlayerPrefs.GetInt(PlayerPrefsKeys.AdsActiveKey, 1) != 0;
    public bool _soundsPaused => PlayerPrefs.GetInt(PlayerPrefsKeys.SoundsPausedKey, 0) != 0;
    public bool _vibroOff => PlayerPrefs.GetInt(PlayerPrefsKeys.VibrationOffKey, 0) != 0;
    
    public ThemeManager.GameThemes GameThemeUI => (ThemeManager.GameThemes) PlayerPrefs.GetInt(PlayerPrefsKeys.ThemeUI, 0);

    public void SaveInt(string _key, int _value)
    {
        PlayerPrefs.SetInt(_key, _value);
    }
    
    public void SaveTheme(ThemeManager.GameThemes gameTheme)
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.ThemeUI, (int) gameTheme);
    }
}
using Currencies;
using UI;
using UnityEngine;

public class SaveGameState : MonoBehaviour
{
    public int _totalLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.TotalLevelKey, 1);
    public int _locationID => PlayerPrefs.GetInt(PlayerPrefsKeys.LocationIDKey, 0);
    public int _currentLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.CurrentLevelKey, 0);

    public int _healthLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.HealthLevelKey, 1);
    public int _attackLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.DamageLevelKey, 1);
    public int _coins
    {
        get { return PlayerPrefs.GetInt(PlayerPrefsKeys.CoinsKey, 0); }
        set { PlayerPrefs.SetInt(PlayerPrefsKeys.CoinsKey, value); }
    }

    public int _playerSkinID => PlayerPrefs.GetInt(PlayerPrefsKeys.PlayerSkinID, 0);
    public int _playerMegaslapSkinID => PlayerPrefs.GetInt(PlayerPrefsKeys.PlayerMegaslapSkinID, 0);

    public bool _adsActive => PlayerPrefs.GetInt(PlayerPrefsKeys.AdsActiveKey, 1) != 0;
    public bool _soundsPaused => PlayerPrefs.GetInt(PlayerPrefsKeys.SoundsPausedKey, 0) != 0;
    public bool _vibroOff => PlayerPrefs.GetInt(PlayerPrefsKeys.VibrationOffKey, 0) != 0;

    public ThemeManager.GameThemes GameThemeUI
    {
        get { return (ThemeManager.GameThemes) PlayerPrefs.GetInt(PlayerPrefsKeys.ThemeUI, 0); }
        set { PlayerPrefs.SetInt(PlayerPrefsKeys.ThemeUI, (int) value); }
    }
    public int Marshmallows
    {
        get { return PlayerPrefs.GetInt(PlayerPrefsKeys.MarshmallowsKey, 0); }
        set { PlayerPrefs.SetInt(PlayerPrefsKeys.MarshmallowsKey, value); }
    }
    
    public int Skins
    {
        get { return PlayerPrefs.GetInt(PlayerPrefsKeys.MarshmallowsKey, 0); }
        set { PlayerPrefs.SetInt(PlayerPrefsKeys.MarshmallowsKey, value); }
    }

    public void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

}
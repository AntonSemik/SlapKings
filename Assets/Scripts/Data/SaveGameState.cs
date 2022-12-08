using Currencies;
using UI;
using UnityEngine;
using System.Collections.Generic;

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
    
    public int Skins //Dont see any links, what is it?
    {
        get { return PlayerPrefs.GetInt(PlayerPrefsKeys.MarshmallowsKey, 0); }
        set { PlayerPrefs.SetInt(PlayerPrefsKeys.MarshmallowsKey, value); }
    }

    public int Booster_Megaslap
    {
        get { return PlayerPrefs.GetInt(PlayerPrefsKeys.Boosters_MegaslapKey, 0); }
        set { PlayerPrefs.SetInt(PlayerPrefsKeys.Boosters_MegaslapKey, value); }
    }

    public int Booster_Protection
    {
        get { return PlayerPrefs.GetInt(PlayerPrefsKeys.Boosters_ProtectionKey, 0); }
        set { PlayerPrefs.SetInt(PlayerPrefsKeys.Boosters_ProtectionKey, value); }
    }

    //=====================
    //Save and load methods
    //=====================
    public void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public void SaveBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public bool LoadBool(string key)
    {
        return PlayerPrefs.GetInt(key) != 0;
    }
}
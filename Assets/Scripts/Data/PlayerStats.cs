using UnityEngine;

public class PlayerStats
{    
    private const int StartHealth = 100;
    private const int StartDamage = 44;
    private const int HealthProgressionPerLevel = 25;
    private const int DamageProgressionPerLevel = 15;

    public int HealthLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.HealthLevelKey, 0);
    public int DamageLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.DamageLevelKey, 0);

    public int Health => StartHealth + HealthLevel * HealthProgressionPerLevel;
    public int Damage => StartDamage + DamageLevel * DamageProgressionPerLevel;

    public void SaveHealthLevel(int level) =>
        PlayerPrefs.SetInt(PlayerPrefsKeys.HealthLevelKey, 0);
    
    public void SaveDamageLevel(int level) =>
        PlayerPrefs.SetInt(PlayerPrefsKeys.DamageLevelKey, 0);
}

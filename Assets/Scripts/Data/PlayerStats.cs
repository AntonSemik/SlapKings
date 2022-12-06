using UnityEngine;

public class PlayerStats
{
    private const int StartHealth = 75;
    private const int StartDamage = 20;
    private const int HealthProgressionPerLevel = 25;
    private const int DamageProgressionPerLevel = 15;
    public const int StartCost = 50;
    public const int CostProgressPerLevel = 50;

    public int HealthLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.HealthLevelKey, 1);
    public int DamageLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.DamageLevelKey, 1);

    public int Health => StartHealth + HealthLevel * HealthProgressionPerLevel;
    public int Damage => StartDamage + DamageLevel * DamageProgressionPerLevel;

    public void SaveHealthLevel(int level)
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.HealthLevelKey, level);
        Singletons.Instance.HealthPanelAnimator.SetDefaultValues(Health);
    }

    public void SaveDamageLevel(int level)
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.DamageLevelKey, level);
        Singletons.Instance.Indicator.SetDamageText(Damage.ToString());
    }
}
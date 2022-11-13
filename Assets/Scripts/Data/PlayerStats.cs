using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{    
    private const int StartHealth = 100;
    private const int StartDamage = 44;
    private const int HealthProgressionPerLevel = 25;
    private const int DamageProgressionPerLevel = 15;
    private const int StartCost = 50;
    private const int CostProgressPerLevel = 50;

    public int HealthLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.HealthLevelKey, 1);
    public int DamageLevel => PlayerPrefs.GetInt(PlayerPrefsKeys.DamageLevelKey, 1);

    public int Health => StartHealth + HealthLevel * HealthProgressionPerLevel;
    public int Damage => StartDamage + DamageLevel * DamageProgressionPerLevel;

    [SerializeField] TMP_Text _damageCostText;
    [SerializeField] TMP_Text _damageLevelText;
    [SerializeField] TMP_Text _healthCostText;
    [SerializeField] TMP_Text _healthLevelText;

    public void SaveHealthLevel(int level) =>
        PlayerPrefs.SetInt(PlayerPrefsKeys.HealthLevelKey, level);
    
    public void SaveDamageLevel(int level) =>
        PlayerPrefs.SetInt(PlayerPrefsKeys.DamageLevelKey, level);

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _damageCostText.text = CalculateCost(DamageLevel).ToString();
        _damageLevelText.text = "POWER (" + DamageLevel.ToString() + ")";

        _healthCostText.text = CalculateCost(HealthLevel).ToString();
        _healthLevelText.text = "HEALTH (" + HealthLevel.ToString() + ")";

        Singletons._s.Indicator.SetDamageText(Damage.ToString());
        Singletons._s.HealthPanelAnimator.SetDefaultValues(Health);
    }

    public void UpgradeHealth()
    {
        if (Singletons._s.Coins.IsEnough(CalculateCost(HealthLevel)))
        {
            Singletons._s.Coins.ChangeCoins(-CalculateCost(HealthLevel));

            SaveHealthLevel(HealthLevel + 1);

            UpdateUI();
        }
    }
    public void UpgradeDamage()
    {
        if (Singletons._s.Coins.IsEnough(CalculateCost(DamageLevel)))
        {
            Singletons._s.Coins.ChangeCoins(-CalculateCost(DamageLevel));

            SaveDamageLevel(DamageLevel + 1);

            UpdateUI();
        }
    }

    private int CalculateCost(int _level)
    {
        return StartCost + CostProgressPerLevel * _level;
    }
}

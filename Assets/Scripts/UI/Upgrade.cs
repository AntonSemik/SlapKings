using UnityEngine;
using TMPro;
public class Upgrade : MonoBehaviour
{
    [SerializeField] TMP_Text _damageCostText;
    [SerializeField] TMP_Text _damageLevelText;
    [SerializeField] TMP_Text _healthCostText;
    [SerializeField] TMP_Text _healthLevelText;
    private PlayerStats _playerStats = new PlayerStats();

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _damageCostText.text = CalculateCost(_playerStats.DamageLevel).ToString();
        _damageLevelText.text = "POWER (" + _playerStats.DamageLevel.ToString() + ")";

        _healthCostText.text = CalculateCost(_playerStats.HealthLevel).ToString();
        _healthLevelText.text = "HEALTH (" + _playerStats.HealthLevel.ToString() + ")";        
    }

    public void UpgradeHealth()
    {
        if (Singletons._singletons.Coins.IsEnough(CalculateCost(_playerStats.HealthLevel)))
        {
            Singletons._singletons.Coins.ChangeCoins(-CalculateCost(_playerStats.HealthLevel));

            _playerStats.SaveHealthLevel(_playerStats.HealthLevel + 1);

            UpdateUI();
        }
    }
    public void UpgradeDamage()
    {
        if (Singletons._singletons.Coins.IsEnough(CalculateCost(_playerStats.DamageLevel)))
        {
            Singletons._singletons.Coins.ChangeCoins(-CalculateCost(_playerStats.DamageLevel));

            _playerStats.SaveDamageLevel(_playerStats.DamageLevel + 1);

            UpdateUI();
        }
    }

    private int CalculateCost(int _level)
    {
        return PlayerStats.StartCost + PlayerStats.CostProgressPerLevel * _level;
    }
}

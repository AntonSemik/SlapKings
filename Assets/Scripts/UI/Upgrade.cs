using UnityEngine;
using TMPro;
public class Upgrade : MonoBehaviour
{
    [SerializeField] TMP_Text _damageCostText;
    [SerializeField] TMP_Text _damageLevelText;
    [SerializeField] TMP_Text _healthCostText;
    [SerializeField] TMP_Text _healthLevelText;
    [SerializeField] private GameObject _healthCost;
    [SerializeField] private GameObject _healthAd;
    private PlayerStats _playerStats = new PlayerStats();

    private void Start()
    {
        Singletons._singletons.Coins.CoinsChanged += OnCoinsChanged;
        UpdateUI();
    }

    private void OnCoinsChanged()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _damageCostText.text = CalculateCost(_playerStats.DamageLevel).ToString();
        _damageLevelText.text = "POWER (" + _playerStats.DamageLevel.ToString() + ")";

        UpdateHealthUpButton(IsEnough(_playerStats.HealthLevel));
    }

    public void UpgradeHealth()
    {
        bool isEnough = IsEnough(_playerStats.HealthLevel);
        
        if (isEnough)
        {
            Singletons._singletons.Coins.ChangeCoins(-CalculateCost(_playerStats.HealthLevel));

            _playerStats.SaveHealthLevel(_playerStats.HealthLevel + 1);

            UpdateUI();
        }
    }

    private bool IsEnough(int value)
    {
        return Singletons._singletons.Coins.IsEnough(CalculateCost(value));
    }

    private void UpdateHealthUpButton(bool isEnough)
    {
        _healthCostText.text = CalculateCost(_playerStats.HealthLevel).ToString();
        _healthLevelText.text = "HEALTH (" + _playerStats.HealthLevel.ToString() + ")";
        _healthCost.SetActive(isEnough);
        _healthAd.SetActive(!isEnough);
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
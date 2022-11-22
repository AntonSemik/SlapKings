using UnityEngine;
using TMPro;
public class Upgrade : MonoBehaviour
{
    [SerializeField] TMP_Text _damageCostText;
    [SerializeField] TMP_Text _damageLevelText;
    [SerializeField] private GameObject _damageCost;
    [SerializeField] private GameObject _damageAd;
    [SerializeField] private GameObject _damageIcon;
    
    [SerializeField] TMP_Text _healthCostText;
    [SerializeField] TMP_Text _healthLevelText;
    [SerializeField] private GameObject _healthCost;
    [SerializeField] private GameObject _healthAd;
    [SerializeField] private GameObject _healthIcon;
    
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
        UpdateDamageUpButton();
        UpdateHealthUpButton();
    }

    public void UpgradeHealth()
    {
        _playerStats.SaveHealthLevel(_playerStats.HealthLevel + 1);

        UpgrageForPriceOrAds(_playerStats.HealthLevel);
        UpdateUI();
    }

    private void UpgrageForPriceOrAds(int level)
    {
        if (IsEnough(level))
            Singletons._singletons.Coins.ChangeCoins(-CalculateCost(level));
        else
            Singletons._singletons.AdsPlaceholder.ShowAd();
    }

    private bool IsEnough(int value)
    {
        return Singletons._singletons.Coins.IsEnough(CalculateCost(value));
    }

    private void UpdateHealthUpButton()
    {
        bool isEnough = IsEnough(_playerStats.HealthLevel);
        
        _healthCostText.text = CalculateCost(_playerStats.HealthLevel).ToString();
        _healthLevelText.text = "HEALTH (" + _playerStats.HealthLevel.ToString() + ")";
        _healthCost.SetActive(isEnough);
        _healthAd.SetActive(!isEnough);
        _healthIcon.SetActive(isEnough);
    }
    
    private void UpdateDamageUpButton()
    {
        bool isEnough = IsEnough(_playerStats.DamageLevel);
        
        _damageCostText.text = CalculateCost(_playerStats.DamageLevel).ToString();
        _damageLevelText.text = "POWER (" + _playerStats.DamageLevel.ToString() + ")";
        _damageCost.SetActive(isEnough);
        _damageAd.SetActive(!isEnough);
        _damageIcon.SetActive(isEnough);
    }

    public void UpgradeDamage()
    {
        _playerStats.SaveDamageLevel(_playerStats.DamageLevel + 1);
        
        UpgrageForPriceOrAds(_playerStats.DamageLevel);
        UpdateUI();
    }

    private int CalculateCost(int _level)
    {
        return PlayerStats.StartCost + PlayerStats.CostProgressPerLevel * _level;
    }
}
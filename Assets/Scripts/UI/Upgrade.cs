using UnityEngine;
using TMPro;
public class Upgrade : MonoBehaviour
{
    [SerializeField] TMP_Text _damageCostText;
    [SerializeField] TMP_Text _damageLevelText;
    [SerializeField] private GameObject _damageCost;
    [SerializeField] private GameObject _damageAd;
    [SerializeField] private GameObject _damageIcon;
    private bool _adsDamageUpgradeAvailable = true;
    
    [SerializeField] TMP_Text _healthCostText;
    [SerializeField] TMP_Text _healthLevelText;
    [SerializeField] private GameObject _healthCost;
    [SerializeField] private GameObject _healthAd;
    [SerializeField] private GameObject _healthIcon;
    private bool _adsHealthUpgradeAvailable = true;

    private PlayerStats _playerStats = new PlayerStats();

    private void Start()
    {
        Singletons.Instance.Coins.OnChanged += OnCoinsChanged;
        Singletons.Instance.GameStateMachine.LevelComplete += ResetAds;
        Singletons.Instance.GameStateMachine.LevelFailed += ResetAds;

        UpdateUI();
    }

    private void OnCoinsChanged(int value)
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
        if (IsEnough(_playerStats.HealthLevel))
        {
            int level = _playerStats.HealthLevel + 1;
            _playerStats.SaveHealthLevel(level);
            Singletons.Instance.Coins.ChangeValue(-CalculateCost(level));
            UpdateUI();

            return;
        }

        if (_adsHealthUpgradeAvailable)
        {
            UpgrageForAd();
            _playerStats.SaveHealthLevel(_playerStats.HealthLevel + 1);

            _adsHealthUpgradeAvailable = false;

            UpdateUI();
        }
    }

    public void UpgradeDamage()
    {
        if (IsEnough(_playerStats.DamageLevel))
        {
            int level = _playerStats.HealthLevel + 1;
            _playerStats.SaveDamageLevel(level);
            Singletons.Instance.Coins.ChangeValue(-CalculateCost(level));
            UpdateUI();

            return;
        }

        if (_adsDamageUpgradeAvailable)
        {
            UpgrageForAd();
            _playerStats.SaveDamageLevel(_playerStats.DamageLevel + 1);

            _adsDamageUpgradeAvailable = false;

            UpdateUI();
        }
    }

    private void UpgrageForAd()
    {
            Singletons.Instance.AdsPlaceholder.ShowDemandedAd();
    }

    private bool IsEnough(int value)
    {
        return Singletons.Instance.Coins.IsEnough(CalculateCost(value));
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

    private int CalculateCost(int _level)
    {
        return PlayerStats.StartCost + PlayerStats.CostProgressPerLevel * _level;
    }

    private void ResetAds()
    {
        _adsDamageUpgradeAvailable = true;
        _adsHealthUpgradeAvailable = true;
    }
}
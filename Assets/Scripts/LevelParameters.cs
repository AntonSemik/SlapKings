using System;
using UnityEngine;
using TMPro;
using UI;

public class LevelParameters : MonoBehaviour
{
    [SerializeField] BaseEnemyValues BaseEnemyValues;

    [SerializeField] Location[] _locations;
    private Location _currentLocation;

    [SerializeField] TMP_Text _levelText;

    private int _locationID = 0;
    private int _currentLevel = 0;
    public int _totalLevel { private set; get; }
    public int bonusLevelNumber { get; } = 4; //����������

    public int _baseReward { private set; get; }
    public int _enemyHealth { private set; get; }
    public int _enemyDamageBase { private set; get; }

    public Slaper GetEnemy()
    {
        return _locations[_locationID]._enemies[_currentLevel];
    }

    public void LoadCurrentLevel()
    {
        _totalLevel = Singletons.Instance.SaveGameState._totalLevel;
        _locationID = Singletons.Instance.SaveGameState._locationID;
        _currentLevel = Singletons.Instance.SaveGameState._currentLevel;

        SetNewLocation();
        SetLevelScene();

        _levelText.text = "Level: " + _totalLevel.ToString();
    }

    public void IncreaseLevel()
    {   
        _totalLevel++;
        _currentLevel++;

        if (_currentLevel >= _currentLocation._enemies.Length)
        {
            _locationID++;
            _currentLevel = 0;

            if (_locationID >= _locations.Length)
            {
                _locationID = 0;
            }

            SetNewLocation();
        }

        Singletons.Instance.SaveGameState.SaveInt(PlayerPrefsKeys.TotalLevelKey, _totalLevel);
        Singletons.Instance.SaveGameState.SaveInt(PlayerPrefsKeys.CurrentLevelKey, _currentLevel);
        Singletons.Instance.SaveGameState.SaveInt(PlayerPrefsKeys.LocationIDKey, _locationID);
    }

    private void SetLevelScene()
    {
        CalculateLevelParameters();

        _levelText.text = "Level: " + _totalLevel.ToString();
    }
    
    private void SetNewLocation()
    {
        _currentLocation?.gameObject.SetActive(false);

        _currentLocation = _locations[_locationID];
        _currentLocation.gameObject.SetActive(true);
    }

    private void CalculateLevelParameters()
    {
        _baseReward = BaseEnemyValues.BaseReward * _totalLevel;
        _enemyHealth = BaseEnemyValues.BaseHealth + BaseEnemyValues.HealthPerLevel * _totalLevel;
        _enemyDamageBase = BaseEnemyValues.BaseDamage + BaseEnemyValues.DamagePerLevel * _totalLevel;
    }
}
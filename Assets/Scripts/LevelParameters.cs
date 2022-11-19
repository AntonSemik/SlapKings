using UnityEngine;
using TMPro;

public class LevelParameters : MonoBehaviour
{
    [SerializeField] Location[] _locations;

    [SerializeField] TMP_Text _levelText;

    private int _locationID = 0;

    public int _level { private set; get; }
    public int bonusLevelNumber { get; } = 4;

    public bool _isBonus { private set; get; }
    public int _baseReward { private set; get; }
    public int _enemyHealth { private set; get; }
    public int _enemyDamageBase { private set; get; }

    public Slaper GetEnemy() => _isBonus ? _locations[_locationID]._bonusLevelEnemy : _locations[_locationID]._characters[(_level % 4) - 1];

    public void Load(int level)
    {
        _level = level;

        _isBonus = _level % bonusLevelNumber == 0;

        SetNewLocation();
        SetLevelScene();
        _levelText.text = "Level: " + _level.ToString();
    }
    
    public void IncreaseLevel()
    {   
        _level++;
        
        Singletons._singletons.SaveGameState.SaveInt("Level", _level);
        
        _isBonus = _level % bonusLevelNumber == 0;
    }
    
    private void SetLevelScene()
    {
        CalculateLevelParameters();

        if (_locationID != Mathf.FloorToInt(_level / bonusLevelNumber)) SetNewLocation();

        _levelText.text = "Level: " + _level.ToString();
    }
    
    private void SetNewLocation()
    {
        _locations[_locationID].gameObject.SetActive(false);

        _locationID = Mathf.FloorToInt((_level - 1) / bonusLevelNumber);
        while (_locationID >= _locations.Length) _locationID -= _locations.Length;

        _locations[_locationID].gameObject.SetActive(true);
    }

    private void CalculateLevelParameters()
    {
        _baseReward = 25 * _level;
        _enemyHealth = 70 + 30 * _level;
        _enemyDamageBase = 10 + 15 * _level;

        if (_isBonus)
        {
            _baseReward += 75;
        }
    }
}
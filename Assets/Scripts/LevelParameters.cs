using UnityEngine;
using TMPro;

public class LevelParameters : MonoBehaviour
{
    [SerializeField] Location[] _locations;

    [SerializeField] TMP_Text _levelText;

    private Location _currentLocation;
    private int _locationID = 0;

    private int _level;


    public bool _isBonus { private set; get; }
    public int _baseReward { private set; get; }
    public int _enemyHealth { private set; get; }
    public int _enemyDamageBase { private set; get; }

    private void Start()
    {
        _level = Singletons._s.SaveGameState._level;
        _currentLocation = _locations[0];

        _isBonus = _level % 4 == 0;

        SetNewLocation();
        SetLevelScene();
        _levelText.text = "Level: " + _level.ToString();

        Singletons._s.Fight.PlayerWin += OnFightEnded;
    }

    private void SetLevelScene()
    {
        CalculateLevelParameters();

        if (_locationID != Mathf.FloorToInt(_level / 4)) SetNewLocation();

        _levelText.text = "Level: " + _level.ToString();
    }

    private void SetNewLocation()
    {
        _locationID = Mathf.FloorToInt(_level / 4);
        while (_locationID > _locations.Length) _locationID -= _locations.Length;


        _currentLocation._surroundings.SetActive(false);

        _currentLocation = _locations[_locationID];
        _currentLocation._surroundings.SetActive(true);
    }

    private void OnFightEnded(bool _isPlayerVictorious)
    {
        if (_isPlayerVictorious)
        {
            IncreaseLevel();

            SetLevelScene();

            return;
        }
        
        if(_isBonus)
        {
            IncreaseLevel();

            SetLevelScene();
        }
    }

    private void IncreaseLevel()
    {
        _level++;
        Singletons._s.SaveGameState.SaveInt("Level", _level);

        _isBonus = _level % 4 == 0;
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
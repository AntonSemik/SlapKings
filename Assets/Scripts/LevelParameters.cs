using UnityEngine;

public class LevelParameters : MonoBehaviour
{
    [SerializeField] Location[] _locations;
    private Location _currentLocation;
    private int _locationID = 0;

    private int _level;

    private int _baseReward;
    private int _enemyHealth;
    private int _enemyDamageBase;

    private void Start()
    {
        _level = Singletons._s.LevelParameters._level;
        _currentLocation = _locations[0];

        SetNewLocation();
        SetLevelScene();
        //UpdateUI
    }

    void SetLevelScene()
    {
        CalculateLevelParameters();

        if (_locationID != Mathf.FloorToInt(_level / 4)) SetNewLocation();

        //UpdateUI
    }

    void SetNewLocation()
    {
        _locationID = Mathf.FloorToInt(_level / 4);
        while (_locationID > _locations.Length) _locationID -= _locations.Length;


        _currentLocation._surroundings.SetActive(false);

        _currentLocation = _locations[_locationID];
        _currentLocation._surroundings.SetActive(true);
    }

    public Vector2 GetEnemyStats()
    {
        return new Vector2(_enemyHealth, _enemyDamageBase);
    }

    public int PlayerWon()
    {
        _level++;
        Singletons._s.SaveGameState.SaveInt("Level", _level);

        int _reward = _baseReward * 4;

        SetLevelScene();

        Debug.Log("Reward for win: " + _reward);
        return _reward;
    }

    public int PlayerLost()
    {
        Debug.Log("Reward for lose: " + _baseReward);
        return _baseReward;
    }

    private void CalculateLevelParameters()
    {
        _baseReward = 25 * _level;
        _enemyHealth = 70 + 30 * _level;
        _enemyDamageBase = 10 + 15 * _level;
    }
}
using System;
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

    public event Action ChangeThemeUI;
    public enum Themes { King, Princess }
    public Themes GameTheme { private set; get; } = Themes.King;

    private void Awake()
    {
        // GameTheme = Themes.King;
    }

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
        SwitchThemeUI();
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

    #if UNITY_EDITOR
    private void Update()
    {
        if (UnityEngine.Input.GetKeyUp(KeyCode.T))
        {
            SwitchThemeUI();
            Debug.Log("KeyCode");
        }
    }
    #endif
    
    public void SwitchThemeUI()
    {
        Debug.Log("SwitchThemeUI");
        SetThemeUI(GameTheme == Themes.King ? Themes.Princess : Themes.King);
    }

    private void SetThemeUI(Themes theme)
    {
        GameTheme = theme;
        Debug.Log("SetThemeUI " + GameTheme);
        ChangeThemeUI?.Invoke();
    }
    
}
using System;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _coinsUI;
    private GameStateMachine _stateMachine;
    private int _coins;

    public event Action CoinsChanged;

    private void Awake()
    {
        SetDependencies();

        foreach (TMP_Text text in _coinsUI)
        {
            text.text = _coins.ToString();
        }
    }

    public void GiveReward(int _multyplier)
    {
        int _reward;
        _reward = Singletons._singletons.LevelParameters._baseReward * _multyplier;
        ChangeCoins(_reward);
    }

    public void ChangeCoins(int _amount)
    {
        _coins += _amount;

        Singletons._singletons.SaveGameState.SaveInt(PlayerPrefsKeys.CoinsKey, _coins);

        foreach (TMP_Text text in _coinsUI)
        {
            text.text = _coins.ToString();
        }
        
        CoinsChanged?.Invoke();
    }

    public bool IsEnough(int _amountNeeded)
    {
        return _amountNeeded <= _coins;
    }

    private void OnLevelComplete() =>
        GiveReward(4);
    private void OnLevelFailed() =>
        GiveReward(1);
    private void SetDependencies()
    {
        _coins = Singletons._singletons.SaveGameState._coins;
        _stateMachine = Singletons._singletons.GameStateMachine;
        _stateMachine.LevelComplete += OnLevelComplete;
        _stateMachine.LevelFailed += OnLevelFailed;
    }
}
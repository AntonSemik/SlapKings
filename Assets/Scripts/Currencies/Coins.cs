using System;
using Currencies;
using Shop;
using UnityEngine;
using TMPro;

public class Coins : Currency
{
    private GameStateMachine _stateMachine;

    public Coins(CurrencyData settings)
    {
        Init(settings);
        Total = Singletons.Instance.SaveGameState._coins;
        SetDependencies();
    }

    public void GiveReward(int _multyplier)
    {
        int _reward;
        _reward = Singletons.Instance.LevelParameters._baseReward * _multyplier;
        ChangeValue(_reward);
    }

    public override void ChangeValue(int value)
    {
        base.ChangeValue(value);
        Singletons.Instance.SaveGameState._coins = Total;
    }

    private void OnLevelComplete() =>
        GiveReward(4);
    private void OnLevelFailed() =>
        GiveReward(1);
    
    private void SetDependencies()
    {
        _stateMachine = Singletons.Instance.GameStateMachine;
        _stateMachine.LevelComplete += OnLevelComplete;
        _stateMachine.LevelFailed += OnLevelFailed;
    }
}
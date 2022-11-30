using System;
using Currencies;
using UnityEngine;
using TMPro;

public class Coins : Currency
{
    private GameStateMachine _stateMachine;

    public Coins()
    {
        CurrencyType = CurrencyType.Coins;
        Total = Singletons._singletons.SaveGameState._coins;
        SetDependencies();
    }

    public void GiveReward(int _multyplier)
    {
        int _reward;
        _reward = Singletons._singletons.LevelParameters._baseReward * _multyplier;
        ChangeValue(_reward);
    }

    public override void ChangeValue(int value)
    {
        base.ChangeValue(value);
        Singletons._singletons.SaveGameState._coins = Total;
    }

    private void OnLevelComplete() =>
        GiveReward(4);
    private void OnLevelFailed() =>
        GiveReward(1);
    
    private void SetDependencies()
    {
        _stateMachine = Singletons._singletons.GameStateMachine;
        _stateMachine.LevelComplete += OnLevelComplete;
        _stateMachine.LevelFailed += OnLevelFailed;
    }
}
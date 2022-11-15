using UnityEngine;
using System.Collections;

public class BonusEnemyTurn : Turn<BonusEnemy>
{
    private const int MaxTurnsAmount = 3;
    protected override BonusEnemy _slaper => (BonusEnemy)_fightState.Enemy;
    private int _turnsAmount;
    private Rotator _rotator => _slaper.Rotator;

    public override void EndTurn() =>
        _rotator.Reset();

    public override void StartTurn()
    {        
        _turnsAmount++;
        if (_turnsAmount == MaxTurnsAmount)
        {
            _fightState.StateMachine.InvokeLevelComplete();
            _turnsAmount = 0;
        }
        _fightState.StartPlayerTurn();
    }


    protected override void OnKnokedDown()
    {
        _fightState.StateMachine.InvokeLevelComplete();
        _turnsAmount = 0;
    }

    

    protected override void OnHittedAnimationEnd() =>
        _fightState.StartEnemyTurn();
    
    protected override void OnSlapedOpponent() { }
}

using UnityEngine;
using System.Collections;

public class BonusEnemyTurn : Turn<BonusEnemy>
{
    private const int MaxTurnsAmount = 3;
    protected override BonusEnemy _slaper => (BonusEnemy)_fightState.Enemy; //Вот этот каст не работает и все ложится.
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


    protected override void OnKnockedDown() //ДАНИЛ ЭТОТ МЕТОД НЕ ВЫЗЫВАЕТСЯ
    {
        _slaper.ExplosionVFX.Play();

        StartCoroutine(EndLevelWithDelay(2.0f));
    }

    private IEnumerator EndLevelWithDelay(float seconds)
    {
        _turnsAmount = 0;
        _slaper.EnableRagdoll();

        yield return new WaitForSeconds(seconds);
        _fightState.StateMachine.InvokeLevelComplete();
    }

    protected override void OnHittedAnimationEnd() =>
        _fightState.StartEnemyTurn();
    
    protected override void OnSlapedOpponent() { }
}

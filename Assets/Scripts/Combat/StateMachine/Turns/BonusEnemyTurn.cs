using UnityEngine;
using System.Collections;

public class BonusEnemyTurn : EnemyTurn
{
    private const int MaxTurnsAmount = 3;
    protected override Enemy _slaper => (BonusEnemy)_fightState.Enemy; //Not valid?
    private int _turnsAmount;
    private Rotator _rotator => ((BonusEnemy)_slaper).Rotator;

    public override void EndTurn() =>
        _rotator.Reset();

    public override void StartTurn()
    {
        if (_slaper.CurrentHealth <= 0)
            return;
        _turnsAmount++;
        if (_turnsAmount == MaxTurnsAmount)
        {
            _fightState.StateMachine.InvokeLevelComplete();
            _turnsAmount = 0;
            return;
        }
        _fightState.StartPlayerTurn();
    }

    protected override void OnKnockedDown()
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
}

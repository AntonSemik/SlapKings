using UnityEngine;
using System.Collections;

public class EnemyTurn : Turn<Enemy>
{
    [SerializeField] private GameObject _armorButton;

    protected override Enemy _slaper => _fightState.Enemy;

    public void SetArmor()
    {
        _fightState.Player.SetDamageDivider(Player.MultiplierDouble);
        _armorButton.gameObject.SetActive(false);
        Singletons._singletons.AdsPlaceholder.ShowAd();
    }
    public override void StartTurn()
    {
        _armorButton.SetActive(true);
        StartCoroutine(SlapWithDelay(0.5f));
        _fightState.CameraMover.LookAtEnemy();
    }

    public override void EndTurn() => 
        _armorButton.SetActive(false);

    protected override void OnKnockedDown()
    {
        StartCoroutine(EndLevelWithDelay(1.0f));
    }

    private IEnumerator EndLevelWithDelay(float seconds)
    {
        _slaper.EnableRagdoll();

        yield return new WaitForSeconds(seconds);

        _fightState.StateMachine.InvokeLevelComplete();
    }

    protected override void OnSlapedOpponent()
    {
        _fightState.Player.ReceiveDamage(_slaper.Damage / _fightState.Player.DamageDivider);
        _fightState.Player.SetDamageDivider(Player.MultiplierSingle);
    }

    private IEnumerator SlapWithDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _slaper.Slap();
    }

    protected override void OnHittedAnimationEnd() =>
        _fightState.StartEnemyTurn();
}
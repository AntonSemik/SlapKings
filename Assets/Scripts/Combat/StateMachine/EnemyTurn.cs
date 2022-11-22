using UnityEngine;
using System.Collections;

public class EnemyTurn : Turn<Enemy>
{
    [SerializeField] private GameObject _armorButton;

    protected override Enemy _slaper => _fightState.Enemy;

    public void SetArmor()
    {
        _slaper.UsedArmor = true;

        _fightState.Player.SetDamageDivider(Player.MultiplierDouble);
        _armorButton.gameObject.SetActive(false);
        Singletons._singletons.AdsPlaceholder.ShowAd();
    }
    public override void StartTurn()
    {
        if (!_slaper.UsedArmor) _armorButton.SetActive(true);
        StartCoroutine(SlapWithDelay(0.5f));
        _fightState.CameraMover.LookAtEnemy();
    }

    public override void EndTurn() => 
        _armorButton.SetActive(false);

    protected override void OnKnockedDown() //Ётот метод почему-то вызываетс€ и на бонусных уровн€х
    {
        if (Singletons._singletons.LevelParameters._isBonus)
        {
            _slaper.ExplosionVFX?.Play();
        }

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
        _slaper.NormalSlapHitEffect?.Play();

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
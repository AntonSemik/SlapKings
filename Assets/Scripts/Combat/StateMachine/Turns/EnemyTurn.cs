using UnityEngine;
using System.Collections;

public class EnemyTurn : Turn<Enemy>
{
    [SerializeField] private GameObject _armorButton;

    protected override Enemy _slaper => _fightState.Enemy;

    public void SetArmor()
    {
        _slaper.UsedArmor = true;

        _fightState.Player.SetDamageDivider(Player.HalfProtection);
        _armorButton.gameObject.SetActive(false);
        Singletons._singletons.AdsPlaceholder.ShowAd();
    }

    public override void StartTurn()
    {
        if (!_slaper.UsedArmor) _armorButton.SetActive(true);
        _fightState.CameraMover.LookAtEnemy();

        if(_slaper.CurrentHealth <= 0)
            return;
        StartCoroutine(SlapWithDelay(0.5f));
        StartCoroutine(EndTurnWithDelay(2f));
    }

    public override void EndTurn() =>
        _armorButton.SetActive(false);

    protected override void OnKnockedDown() //���� ����� ������-�� ���������� � �� �������� �������
    {
        if (_slaper.Type == Enemy.EnemyType.bonus)
        {
            _slaper.ExplosionVFX?.Play();
        }

        StartCoroutine(EndLevelWithDelay(1.0f));
    }

    protected override void OnSlapedOpponent()
    {
        _slaper.NormalSlapHitEffect?.Play();

        _fightState.Player.ReceiveDamage(Mathf.FloorToInt(_slaper.Damage / _fightState.Player.DamageDivider));
        _fightState.Player.SetDamageDivider(Player.DefaultValue);
    }

    protected override IEnumerator EndTurnWithDelay(float seconds)
    {        
        yield return new WaitForSeconds(seconds);
        _fightState.StartPlayerTurn();
    }

    private IEnumerator EndLevelWithDelay(float seconds)
    {
        _slaper.EnableRagdoll();

        yield return new WaitForSeconds(seconds);

        _fightState.StateMachine.InvokeLevelComplete();
    }
    private IEnumerator SlapWithDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _slaper.Slap();
    }

}
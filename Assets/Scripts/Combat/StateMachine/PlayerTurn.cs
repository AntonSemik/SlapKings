using UnityEngine;
using System.Collections;

public class PlayerTurn : Turn<Player>
{
    [SerializeField] private GameObject _megaSlap;
    [SerializeField] private GameObject _slap;
    [SerializeField] private Indicator _indicator;

    protected override Player _slaper => _fightState.Player;

    private PlayerStats _playerStats = new PlayerStats();

    public void Slap()
    {
        _slaper.Slap();
        _slap.SetActive(false);
        _indicator.SetDamageText(((int)(_slaper.Damage * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent))).ToString());
        _indicator.Stop();
    }

    public override void StartTurn()
    {
        _slap.SetActive(true);
        if (!_slaper.UsedMegaSlap) _megaSlap.SetActive(true);
        _indicator.StartPointerMovement();
        _indicator.gameObject.SetActive(true);
        _indicator.SetDamageText(_slaper.Damage.ToString());
        _fightState.CameraMover.LookAtPlayer();
        _slaper.ResetSlaper(false);
    }

    public override void EndTurn()
    {
        _megaSlap.SetActive(false);
        _slaper.MegaslapObject.SetActive(false);

        if (_fightState.Enemy.Type != Enemy.EnemyType.bonus)
            _indicator.gameObject.SetActive(false);
    }

    protected override void OnKnockedDown()
    {
        StartCoroutine(EndLevelWithDelay(1));
    }

    private IEnumerator EndLevelWithDelay(float seconds)
    {
        _slaper.EnableRagdoll();

        yield return new WaitForSeconds(seconds);

        _megaSlap.SetActive(true);
        _fightState.StateMachine.InvokeLevelFailed();
    }

    protected override void OnHittedAnimationEnd() =>
        _fightState.StartPlayerTurn();

    protected override void OnSlapedOpponent()
    {
        if (_slaper.MegaslapObject.activeSelf)
        {
            _slaper.MegaSlapHitEffect?.Play();
        } else
        {
            _slaper.NormalSlapHitEffect?.Play();
        }

        _fightState.Enemy.ReceiveDamage((int)(_slaper.Damage * _slaper.DamageMultiplier * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent)));
        _slaper.SetDamageMultiplier(Player.MultiplierSingle);
    }

    public void MegaSlap()
    {
        _slaper.UsedMegaSlap = true;
        _slaper.MegaslapObject.SetActive(true);
        _slaper.SetDamageMultiplier(Player.MultiplierDouble);
        ChangeIndicatorText(_playerStats.Damage * _slaper.DamageMultiplier);
        _megaSlap.gameObject.SetActive(false);
        Singletons._singletons.AdsPlaceholder.ShowAd();
    }

    private void ChangeIndicatorText(int value) =>
        _indicator.SetDamageText(value.ToString());
}
using UnityEngine;
using System.Collections;

public class PlayerTurn : Turn<Player>
{
    [SerializeField] private GameObject _megaSlap;
    [SerializeField] private GameObject _slap;
    [SerializeField] private Indicator _indicator;

    protected override Player _slaper => _fightState.Player;

    private PlayerStats _playerStats = new PlayerStats();

    private bool _isMegaslapping, _megaslappingStarted;
    private int _megaSlapTapCounter = 0;

    public void Slap()
    {
        _indicator.Stop();

        if (!_isMegaslapping)
        {
            _indicator.SetDamageText(((int)(_slaper.Damage * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent))).ToString());

            _slaper.Slap();
            _slap.SetActive(false);
        } else
        {
            if (!_megaslappingStarted)
            {
                _megaslappingStarted = true;
                StartCoroutine(SlapWithDelay(_slaper.MegaslapTime));
            }

            _indicator.SetDamageText(((int)(_megaSlapTapCounter * _slaper.DamageMultiplier * _slaper.Damage * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent))).ToString());

            _megaSlapTapCounter++;

            Debug.Log("Total multiplier = " + _megaSlapTapCounter + "; Total damage = " + (_megaSlapTapCounter * _slaper.DamageMultiplier * _slaper.Damage * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent)).ToString());
        }
    }

    private IEnumerator SlapWithDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        _megaslappingStarted = false;

        _slaper.Slap();
        _slap.SetActive(false);
    }

    public override void StartTurn()
    {
        _slap.SetActive(true);

        if (!_slaper.UsedMegaSlap)
        {
            _megaSlap.SetActive(true);
            _megaSlapTapCounter = 0;
        }

        _indicator.StartPointerMovement();
        _indicator.gameObject.SetActive(true);
        _indicator.SetDamageText(_slaper.Damage.ToString());

        _fightState.CameraMover.LookAtPlayer();

        _slaper.ResetSlaper(false);
    }

    public override void EndTurn()
    {
        _megaSlap.SetActive(false);
        _slaper._megaSlapObject.VisibleModelOrigin.SetActive(false);

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
        if (_slaper._megaSlapObject.VisibleModelOrigin.activeSelf)
        {
            _slaper._megaSlapObject.HitVFX?.Play();
        } else
        {
            _slaper.NormalSlapHitEffect?.Play();
        }

        if(!_isMegaslapping) _fightState.Enemy.ReceiveDamage((int)(_slaper.Damage * _slaper.DamageMultiplier * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent)));
        if(_isMegaslapping) _fightState.Enemy.ReceiveDamage((int)(_slaper.Damage * _slaper.DamageMultiplier * _megaSlapTapCounter * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent)));

        _slaper.SetDamageMultiplier(Player.NormalSlap);
        _isMegaslapping = false;
    }

    public void MegaSlap()
    {
        _isMegaslapping = true;
        _slaper.UsedMegaSlap = true;
        _slaper._megaSlapObject.VisibleModelOrigin.SetActive(true);
        _slaper.SetDamageMultiplier(Player.MegaSlap);
        ChangeIndicatorText(Mathf.FloorToInt(_playerStats.Damage * _slaper.DamageMultiplier));
        _megaSlap.gameObject.SetActive(false);
        Singletons._singletons.AdsPlaceholder.ShowAd();
    }

    private void ChangeIndicatorText(int value) =>
        _indicator.SetDamageText(value.ToString());
}
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
        }
        else
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

    public override void StartTurn()
    {
        if (_slaper.CurrentHealth <= 0)
            return;
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
        _slaper._megaSlapObject.ToggleVisibility(false);

        if (_fightState.Enemy.Type != Enemy.EnemyType.bonus)
            _indicator.gameObject.SetActive(false);
    }

    public void MegaSlap()
    {
        _isMegaslapping = true;
        _slaper.UsedMegaSlap = true;
        _slaper._megaSlapObject.ToggleVisibility(true);
        ChangeIndicatorText(Mathf.FloorToInt(_playerStats.Damage * _slaper.DamageMultiplier));
        _megaSlap.gameObject.SetActive(false);

        //Subtract from total Megaslaps
    }

    protected override void OnKnockedDown()
    {
        StartCoroutine(EndLevelWithDelay(1));
    }
    protected override IEnumerator EndTurnWithDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _fightState.StartEnemyTurn();
    }
    protected override void OnSlapedOpponent()
    {
        StartCoroutine(EndTurnWithDelay(1.5f));

        if (_slaper._megaSlapObject.isVisible)
        {
            _slaper._megaSlapObject.OnMegaHit();
        }
        else
        {
            _slaper.NormalSlapHitEffect?.Play();
        }

        if (!_isMegaslapping) _fightState.Enemy.ReceiveDamage((int)(_slaper.Damage * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent)));
        if (_isMegaslapping) _fightState.Enemy.ReceiveDamage((int)(_slaper.Damage * _slaper.DamageMultiplier * _megaSlapTapCounter * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent)));

        _isMegaslapping = false;
    }

    private IEnumerator SlapWithDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        _megaslappingStarted = false;

        _slaper.Slap();
        _slap.SetActive(false);
    }

    private IEnumerator EndLevelWithDelay(float seconds)
    {
        _slaper.EnableRagdoll();

        yield return new WaitForSeconds(seconds);

        _megaSlap.SetActive(true);
        _fightState.StateMachine.InvokeLevelFailed();
    }
    private void ChangeIndicatorText(int value) =>
        _indicator.SetDamageText(value.ToString());
}
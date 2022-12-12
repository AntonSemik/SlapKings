using UnityEngine;
using System.Collections;

public class EnemyTurn : Turn<Enemy>
{
    [SerializeField] private GameObject _armorButton;
    [SerializeField] private GameObject _qtePanel;

    protected override Enemy _slaper => _fightState.Enemy;

    private void OnEnable()
    {  
        if(this.GetType() == typeof(BonusEnemyTurn))
            return;
    }

    private void OnDisable()
    {   
        if(this.GetType() == typeof(BonusEnemyTurn))
            return;
    }

    public void SetArmor()
    {
       _slaper.UsedArmor = true;
       _armorButton.gameObject.SetActive(false);
       
        StartQte();

        //Subtract from total Armor boosters
    }

    private void StartQte()
    {
        if (!_slaper.UsedArmor)
            return;

        _qtePanel.SetActive(true);
        Time.timeScale = 0.1f;
        StartCoroutine(QteDelay(0.2f));
    }

    private void GetQteRewards()
    {
        var qte = _qtePanel.GetComponent<QtePanel>();
        _fightState.Player.SetNewDamageDivider(qte._shieldsCollected);
        Singletons.Instance.Coins.ChangeValue(qte._coinsCollected * 10);
    }

    public override void StartTurn()
    {
        if (!_slaper.UsedArmor) _armorButton.SetActive(true);
        _fightState.CameraMover.LookAtEnemy();

        if (_slaper.CurrentHealth <= 0)
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
        _fightState.Player.Flex();
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

    private IEnumerator QteDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 1;
        _qtePanel.SetActive(false);
        GetQteRewards();
    }
}
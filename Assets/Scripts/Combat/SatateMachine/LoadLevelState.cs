using UnityEngine;

public class LoadLevelState : MonoBehaviour, IGameState
{
    [SerializeField] private HPUI _healthUI;
    [SerializeField] private GameObject _slap;
    [SerializeField] private GameObject _idleUI;
    [SerializeField] private GameStateMachine _stateMachine;
    [SerializeField] private LevelParameters _levelLoader;
    [SerializeField] private Indicator _indicator;

    public void Enter()
    {
        LoadLocation();
        LoadEnemy();
        ResetHealthUI();
        ShowIdleUI();
        ResetIndicator();
        _slap.SetActive(true);
    }

    private void ResetIndicator()
    {
        _indicator.SetDamageText(_stateMachine.Player.Damage.ToString());
        _indicator.StartPointerMovement();
    }

    public void Exit() =>
        HideIdleUI();

    private void LoadLocation() =>
        _levelLoader.Load(Singletons._s.SaveGameState._level);
    private void LoadEnemy() =>
         _stateMachine.Enemy = (Enemy)_levelLoader.GetEnemy();
    private void ResetHealthUI() => 
        _healthUI.SetSlapers(_stateMachine.Player, _stateMachine.Enemy);

    private void ShowIdleUI() =>
        _idleUI.SetActive(true);
    private void HideIdleUI() =>
        _idleUI.SetActive(false);





}


using UnityEngine;

public class LoadLevelState : MonoBehaviour, IGameState
{
    [SerializeField] private HPUI _healthUI;
    [SerializeField] private GameObject _slap;
    [SerializeField] private GameObject _idleUI;
    [SerializeField] private GameStateMachine _stateMachine;
    [SerializeField] private LevelParameters _levelLoader;
    [SerializeField] private Indicator _indicator;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private GameObject[] _screenUI;
    
    public void Enter()
    {
        LoadLocation();
        LoadEnemy();
        ResetHealthUI();
        ShowIdleUI();
        ResetIndicator();
        ResetCameraMover();
        ResetPlayer();
        _slap.SetActive(true);
    }

    private void ResetPlayer() =>
        _stateMachine.Player.ResetSlaper(false);

    private void ResetIndicator()
    {
        _indicator.gameObject.SetActive(true);
        _indicator.SetDamageText(_stateMachine.Player.Damage.ToString());
        _indicator.StartPointerMovement();
    }

    private void ResetCameraMover() =>
        _cameraMover.LookAtPlayer();

    public void Exit() =>
        HideIdleUI();

    private void LoadLocation() =>
        _levelLoader.LoadCurrentLevel();
    private void LoadEnemy()
    {
        _stateMachine.Enemy?.gameObject.SetActive(false);       
        _stateMachine.Enemy = (Enemy)_levelLoader.GetEnemy();
        _stateMachine.Enemy.gameObject.SetActive(true);
    }

    private void ResetHealthUI() => 
        _healthUI.SetSlapers(_stateMachine.Player, _stateMachine.Enemy);

    private void ShowIdleUI() =>
        _idleUI.SetActive(true);
    public void HideIdleUI() =>
        _idleUI.SetActive(false);

    public void SetActiveScreenUI(bool value)
    {
        foreach (var item in _screenUI)
        {
            item.SetActive(value);
        }
    }
}
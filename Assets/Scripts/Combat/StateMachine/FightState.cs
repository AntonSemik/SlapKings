using UnityEngine;

public class FightState : MonoBehaviour, IGameState
{
    [SerializeField] private GameStateMachine _stateMachine;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private PlayerTurn _playerTurn;
    [SerializeField]  private EnemyTurn _enemyTurn;

    [SerializeField] private EnemyTurn _defaultEnemyTurn;
    [SerializeField] private BonusEnemyTurn _bonusEnemyTurn;

    public GameStateMachine StateMachine => _stateMachine;
    public CameraMover CameraMover => _cameraMover;
    public Player Player => _stateMachine.Player;
    public Enemy Enemy => _stateMachine.Enemy;

    public void Enter()
    {
        SetEnemyTurnType();

        _enemyTurn.SubscribeToSlaperEvents(); 
        _playerTurn.SubscribeToSlaperEvents();

        Enemy.ResetSlaper(true);
        Player.ResetSlaper(true);
    }

    public void StartPlayerTurn()
    {   
        _enemyTurn.EndTurn();
        _playerTurn.StartTurn();
    }
    public void StartEnemyTurn()
    {   
        _playerTurn.EndTurn();
        _enemyTurn.StartTurn();
    }

    public void Exit()
    {
        Enemy.UsedArmor = false;
        Player.UsedMegaSlap = false;

        Player._megaSlapObject.ToggleVisibility(false);

        _enemyTurn.UnsubscribeFromSlaperEvents();
        _playerTurn.UnsubscribeFromSlaperEvents();

        if(Enemy.Type == Enemy.EnemyType.bonus)
        {
            Singletons.Instance.ExitLocation.LoadLoadingScene();
        }
    }

    private void SetEnemyTurnType()
    {
        if (Enemy.Type == Enemy.EnemyType.bonus)
            _enemyTurn = _bonusEnemyTurn;
        else
            _enemyTurn = _defaultEnemyTurn;
    }

}
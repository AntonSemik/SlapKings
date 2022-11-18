using UnityEngine;

public class FightState : MonoBehaviour, IGameState
{
    [SerializeField] private GameStateMachine _stateMachine;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private PlayerTurn _playerTurn;
    [SerializeField] private EnemyTurn _enemyTurn;
    [SerializeField] private BonusEnemyTurn _bonusEnemyTurn;

    public GameStateMachine StateMachine => _stateMachine;
    public CameraMover CameraMover => _cameraMover;
    public Player Player => _stateMachine.Player;
    public Enemy Enemy => _stateMachine.Enemy;

    public void Enter()
    {
        _enemyTurn.SubscribeToSlaperEvents();
        _playerTurn.SubscribeToSlaperEvents();
        
        Enemy.ResetSlaper();
        Player.ResetSlaper();
    }

    public void StartPlayerTurn()
    {
        if (Singletons._singletons.LevelParameters._isBonus)
            _bonusEnemyTurn.EndTurn();
        else
            _enemyTurn.EndTurn();

        _playerTurn.StartTurn();
    }

    public void StartEnemyTurn()
    {
        _playerTurn.EndTurn();
        if (Singletons._singletons.LevelParameters._isBonus)
            _bonusEnemyTurn.StartTurn();
        else
            _enemyTurn.StartTurn();
    }

    public void Exit()
    {
        _enemyTurn.UnsubscribeFromSlaperEvents();
        _playerTurn.UnsubscribeFromSlaperEvents();
    }
}




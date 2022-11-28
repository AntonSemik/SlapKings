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
        _enemyTurn.SubscribeToSlaperEvents(); //Где подписка на BonusEnemyTurn??
        _playerTurn.SubscribeToSlaperEvents();

        Enemy.ResetSlaper(true);
        Player.ResetSlaper(true);
    }

    public void StartPlayerTurn()
    {
        if (Enemy.Type == Enemy.EnemyType.bonus)
            _bonusEnemyTurn.EndTurn();
        else
            _enemyTurn.EndTurn();

        _playerTurn.StartTurn();
    }

    public void StartEnemyTurn()
    {
        _playerTurn.EndTurn();
        if (Enemy.Type == Enemy.EnemyType.bonus)
            _bonusEnemyTurn.StartTurn();
        else
            _enemyTurn.StartTurn();
    }

    public void Exit()
    {
        Enemy.UsedArmor = false;
        Player.UsedMegaSlap = false;

        Player.MegaslapObject.SetActive(false);

        _enemyTurn.UnsubscribeFromSlaperEvents();
        _playerTurn.UnsubscribeFromSlaperEvents();
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public event Action LevelComplete;
    public event Action LevelFailed;
    [SerializeField] private LevelParameters _levelLoader;
    public Player Player;
    [HideInInspector] public Enemy Enemy;
    private Dictionary<Type, IGameState> _states;
    private IGameState _current;

    public bool TookExtraSlap = false;

    private void Start()
    {
        InitializeStates();
    }

    public void EnterFightState()
    {
        if (_current is FightState)
            return;
        ChangeState(typeof(FightState));

        TookExtraSlap = false;
    }

    public void InvokeLevelComplete()
    {
        LevelComplete?.Invoke();
        // IncreaseLevel(); // перенес в PanelWinLose.cs
    }

    public void IncreaseLevel()
    {
        _levelLoader.IncreaseLevel();
        ChangeState(typeof(LoadLevelState));
    }

    public void InvokeLevelFailed()
    {
        LevelFailed?.Invoke();
        //ReloadLevel();
        // ResetLevel(); // перенес в PanelWinLose.cs 
        //Не есть хорошо, загрузка уровне не должна лежать в UI // Антон
    }

    public void ResetLevel()
    {
        Player.ResetSlaper(false);
    }

    public void ReloadLevel() =>
         ChangeState(typeof(LoadLevelState));

    public void ChangeState(Type stateType)
    {
        _current?.Exit();
        _current = _states[stateType];
        _current.Enter();
    }

    private void InitializeStates()
    {
        _states = new Dictionary<Type, IGameState>();
        IGameState[] childrenStates = GetComponents<IGameState>();
        foreach (var state in childrenStates)
            _states[state.GetType()] = state;

        ChangeState(typeof(LoadLevelState));
    }

    public void SetPause(bool value)
    {
        Time.timeScale = value == true ? 0 : 1;
    }
}
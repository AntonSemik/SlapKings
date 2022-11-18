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


    private void Start()
    {
        InitializeStates();
    }

    public void EnterFightState()
    {
        if (_current is FightState)
            return;
        ChangeState(typeof(FightState));
    }

    public void InvokeLevelComplete()
    {
        LevelComplete?.Invoke();
        _levelLoader.IncreaseLevel();
        ChangeState(typeof(LoadLevelState));
    }
    public void InvokeLevelFailed()
    {
        LevelFailed?.Invoke();

        ReloadLevel();

        Player.ResetSlaper();
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
}
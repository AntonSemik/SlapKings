using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public event Action LevelComplete;
    public event Action LevelFailed;

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
        if(_current is FightState)
            return;
        ChangeState(typeof(FightState));
    }

    public void InvokeLevelComplete()
    {
        LevelComplete?.Invoke();
        ChangeState(typeof(LoadLevelState));
    }
    public void InvokeLevelFailed()
    {
        LevelFailed?.Invoke();
        ChangeState(typeof(LoadLevelState));
    }


    public void ChangeState(Type stateType)
    {
        _current?.Exit();
        _current = _states[stateType];
        _current.Enter();
    }

    private void InitializeStates()
    {
        _states = new Dictionary<Type, IGameState>();
        IGameState[] childerenStates = GetComponents<IGameState>();
        foreach (var state in childerenStates)
            _states[state.GetType()] = state;

        ChangeState(typeof(LoadLevelState));
    } 


}


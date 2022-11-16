using UnityEngine;

public abstract class Turn<T> : MonoBehaviour where T : Slaper
{
    [SerializeField] protected FightState _fightState;
    protected abstract T _slaper { get; }

    public abstract void StartTurn();
    public abstract void EndTurn();
    protected abstract void OnSlapedOpponent();
    protected abstract void OnHittedAnimationEnd();
    protected abstract void OnKnockedDown();

    public void SubscribeToSlaperEvents()
    {
        _slaper.SlapedOpponent += OnSlapedOpponent;
        _slaper.HittedAnimationEnd += OnHittedAnimationEnd;
        _slaper.KnockedDown += OnKnockedDown;
    }
    public void UnsubscribeFromSlaperEvents()
    {
        _slaper.SlapedOpponent -= OnSlapedOpponent;
        _slaper.HittedAnimationEnd -= OnHittedAnimationEnd;
        _slaper.KnockedDown -= OnKnockedDown;
    }
}
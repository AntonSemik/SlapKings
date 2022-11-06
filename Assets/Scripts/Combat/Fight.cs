using System;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public event Action<bool> PlayerWin;
    private CameraMover _cameraMover;
    private Slaper[] _slapers;
    private int _activeSlaperIndex;


    public void SetupSlappers(Slaper first, Slaper second, int activeSlaper = 0)
    {
        _slapers = new Slaper[2] { first, second };
        SubscribeToSlapersEvents();

        _activeSlaperIndex = activeSlaper;
        SetActiveSlaper();
        CameraSetup();
    }

    private void CameraSetup()
    {
        _cameraMover ??= CameraMover.Instance;
        if (_activeSlaperIndex == 1)
            _cameraMover.InstantLookAtEnemy();
    }

    private void OnSlapeTriggerEnter(Slaper opponent) =>
        opponent.ReceiveDamage(_slapers[_activeSlaperIndex].Damage);
    private void OnHitedAnimationEnd() =>
        ChangeActiveSlaper();
    private void OnKnokedDown()
    {
        bool isPlayerWin = _slapers[_activeSlaperIndex] is Player;

        PlayerWin?.Invoke(isPlayerWin);
        CameraLookAtWinner(isPlayerWin);
        EliminateLooser(isPlayerWin);

        UnsubscribeFromSlapersEvents();
        foreach (var slaper in _slapers)
            slaper.IsCurrentSlaper = false;
    }


    private void ChangeActiveSlaper()
    {
        if (_activeSlaperIndex == 0)
        {
            _slapers[0].IsCurrentSlaper = false;
            _slapers[1].IsCurrentSlaper = true;
            _activeSlaperIndex = 1;
            _cameraMover.LookAtEnemy();
        }
        else
        {
            _slapers[0].IsCurrentSlaper = true;
            _slapers[1].IsCurrentSlaper = false;
            _activeSlaperIndex = 0;
            _cameraMover.LookAtPlayer();
        }
    }
    
    private void SubscribeToSlapersEvents()
    {
        foreach (var slaper in _slapers)
        {
            slaper.SlapeTriggerEnter += OnSlapeTriggerEnter;
            slaper.HitedAnimationEnd += OnHitedAnimationEnd;
            slaper.KnokedDown += OnKnokedDown;
        }
    }
    
    private void UnsubscribeFromSlapersEvents()
    {
        foreach (var slaper in _slapers)
        {
            slaper.SlapeTriggerEnter -= OnSlapeTriggerEnter;
            slaper.HitedAnimationEnd -= OnHitedAnimationEnd;
            slaper.KnokedDown -= OnKnokedDown;
        }
    }
    
    private void SetActiveSlaper()
    {
        for (int i = 0; i < _slapers.Length; i++)
            _slapers[i].IsCurrentSlaper = (i == _activeSlaperIndex);
    }
    
    private void CameraLookAtWinner(bool isPlayerWin)
    {
        if (!isPlayerWin)
            _cameraMover.LookAtPlayer();
        else
            _cameraMover.LookAtEnemy();
    }
    
    private void EliminateLooser(bool isPlayerWin)
    {    // placeholder
        foreach (var slaper in _slapers)
        {
            if(isPlayerWin && slaper is Enemy)
                slaper.gameObject.SetActive(false);

            if(!isPlayerWin && slaper is Player)
                slaper.gameObject.SetActive(false);
        }    
    }
}
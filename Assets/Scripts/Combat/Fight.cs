using UnityEngine;

public class Fight : MonoBehaviour
{
    private CameraMover _cameraMover;
    private Slaper[] _slapers;
    private int _activeSlaperIndex;

    public void SetupSlappers(Slaper first, Slaper second, int activeSlaper = 0)
    {
        _slapers = new Slaper[2] { first, second };
        foreach (var slaper in _slapers)
        {
            slaper.SlapeTriggerEnter += OnSlapeTriggerEnter;
            slaper.HitedAnimationEnd += OnHitedAnimationEnd;
            slaper.IsCurrentSlaper = false;
        }

        _activeSlaperIndex = activeSlaper;
        _slapers[_activeSlaperIndex].IsCurrentSlaper = true;

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
}








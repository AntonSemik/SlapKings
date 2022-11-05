using System;
using UnityEngine;

public abstract class Slaper : MonoBehaviour
{
    protected const string ToSlapAnimation = "Slap";
    protected const string ToHitedAnimation = "Hited";

    [SerializeField] private Collider _mainCollider;
    [SerializeField] private Collider _handCollider;

    public virtual int Damage => _baseDamage;
    public int CurrentHealth => _currentHealth;
    public virtual bool IsCurrentSlaper
    {
        get => _isCurrentSlaper;
        set
        {
            _isCurrentSlaper = value;
            _mainCollider.enabled = !IsCurrentSlaper;
            _handCollider.enabled = IsCurrentSlaper;
        }
    }
    
    public event Action<Slaper> SlapeTriggerEnter;
    public event Action HitedAnimationEnd;
    public event Action<int> DamageReceived;

    protected int _currentHealth;
    protected int _baseDamage;
    private bool _isCurrentSlaper;
    protected Animator _animator;

    protected virtual void Initialize() =>
        _animator = GetComponentInChildren<Animator>();
   
    public void OnHitedAnimationEnd() =>
        HitedAnimationEnd?.Invoke();
    public void ReceiveDamage(int damge)
    {
        _currentHealth -= damge;
        _animator.CrossFade(ToHitedAnimation, 0.2f);
        DamageReceived?.Invoke(damge);
    }
   
    protected virtual void Slap() =>
        _animator.CrossFade(ToSlapAnimation, 0.2f);
    protected void InvokeSlapeTriggerEnter(Slaper opponent) =>
        SlapeTriggerEnter?.Invoke(opponent);

}


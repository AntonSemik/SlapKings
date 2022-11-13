using System;
using UnityEngine;

public abstract class Slaper : MonoBehaviour
{
    protected const string ToSlapAnimation = "Slap";
    protected const string ToHitedAnimation = "Hited";

    [SerializeField] private Collider _mainCollider;
    [SerializeField] private Collider _handCollider;

    public virtual int Damage => _baseDamage;
    public virtual int MaxHealth => _maxHealth;
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
    public event Action KnokedDown;

    [SerializeField] protected int _baseDamage;
    [SerializeField] protected int _maxHealth;
    protected int _currentHealth;
    private bool _isCurrentSlaper;
    protected Animator _animator;

    protected virtual void Initialize() 
    {
        _animator = GetComponentInChildren<Animator>();
        ResetHealth();
    }

    public void OnHitedAnimationEnd() =>
        HitedAnimationEnd?.Invoke();
    public virtual void ReceiveDamage(int damage)
    {
        if (damage >= _currentHealth)
        {
            damage = _currentHealth;
            KnokedDown?.Invoke();
        }
        else
            _animator.CrossFade(ToHitedAnimation, 0.2f);

        _currentHealth -= damage;
        DamageReceived?.Invoke(damage);
    }
    public void ResetHealth() =>
        _currentHealth = MaxHealth;
    protected virtual void Slap() =>
        _animator.CrossFade(ToSlapAnimation, 0.2f);
    protected void InvokeSlapeTriggerEnter(Slaper opponent) =>
        SlapeTriggerEnter?.Invoke(opponent);

}
using System;
using UnityEngine;

public abstract class Slaper : MonoBehaviour
{
    protected const string ToSlapAnimation = "Slap";
    protected const string ToHittedAnimation = "Hitted";

    [SerializeField] protected Animator _animator;

    public virtual int Damage { get; protected set; }
    public virtual int MaxHealth { get; protected set; }
    public int CurrentHealth { get; protected set; }

    public event Action SlapedOpponent;
    public event Action HittedAnimationEnd;
    public event Action<int> DamageReceived;
    public event Action KnokedDown;


    public void OnHittedAnimationEnd() =>
        HittedAnimationEnd?.Invoke();
    public void OnSlapedOpponent() =>
        SlapedOpponent?.Invoke();

    public void Slap() =>
       _animator.CrossFade(ToSlapAnimation, 0.2f);
    public void ReceiveDamage(int damage)
    {   
        if (damage >= CurrentHealth)
        {
            damage = CurrentHealth;
            KnokedDown?.Invoke();
        }
        else
            _animator.CrossFade(ToHittedAnimation, 0.2f);
            

        CurrentHealth -= damage;
        DamageReceived?.Invoke(damage);
    }
    public void ResetHealth() =>
        CurrentHealth = MaxHealth;

}
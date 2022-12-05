using System;
using UnityEngine;

public abstract class Slaper : MonoBehaviour
{
    protected const string ToSlapAnimation = "Slap";
    protected const string ToHittedAnimation = "Hitted";

    [SerializeField] protected Animator _animator;
    [SerializeField] private Sprite _avatar;
    
    protected Rigidbody[] _rigidbodies;
    protected Transform _transform;

    public ParticleSystem NormalSlapHitEffect;

    public virtual int Damage { get; protected set; }
    public virtual int MaxHealth { get; protected set; }
    public int CurrentHealth { get; protected set; }

    public event Action SlapedOpponent;
    public event Action HittedAnimationEnd;
    public event Action<int> DamageReceived;
    public event Action KnockedDown;

    private void Awake()
    {
        _transform = transform;

        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in _rigidbodies)
        {
            rb.isKinematic = true;
        }
    }

    public void OnHittedAnimationEnd() =>
        HittedAnimationEnd?.Invoke();
    public void OnSlapedOpponent() =>
        SlapedOpponent?.Invoke();

    public void Slap() =>
       _animator.CrossFade(ToSlapAnimation, 0.2f);

    public virtual void ReceiveDamage(int damage)
    {
        if (damage >= CurrentHealth)
            damage = CurrentHealth;

        CurrentHealth -= damage;
        DamageReceived?.Invoke(damage);
        
        if (CurrentHealth == 0)
            KnockedDown?.Invoke();
        else
            _animator.CrossFade(ToHittedAnimation, 0.2f);
    }

    protected void InvokeDamageReceived(int damage) => 
        DamageReceived?.Invoke(damage);

    protected void InvokeKnokedDown() => 
        KnockedDown?.Invoke();

    public void ResetSlaper(bool ResetHealth)
    {
        if (ResetHealth)
        {
            CurrentHealth = MaxHealth;
        }

        foreach (Rigidbody rb in _rigidbodies)
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        }
        
        _transform.localPosition = new Vector3(0, 0, 0);
        _transform.localEulerAngles = new Vector3(0, 0, 0); //Doesnt solve root of original problem, now we have enemies jerk on round start

        _animator.enabled = true;
    }

    public void EnableRagdoll()
    {
        _animator.enabled = false;
        foreach(Rigidbody rb in _rigidbodies)
        {
            rb.isKinematic = false;
            rb.AddForce(transform.forward * -300f + transform.up * 500f + transform.right * 200f);
        }
    }

    public Sprite GetAvatar() => _avatar;
}
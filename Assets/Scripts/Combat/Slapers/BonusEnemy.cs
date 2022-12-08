using UnityEngine;
using System.Collections;

public class BonusEnemy : Enemy
{
    public override int Damage => base.Damage;
    public override int MaxHealth => base.MaxHealth;
    public Rotator Rotator;
    [SerializeField] private MeshRenderer _rope;

    public override void ReceiveDamage(int damage)
    {
        if (damage >= CurrentHealth)
            damage = CurrentHealth;

        CurrentHealth -= damage;
        InvokeDamageReceived(damage);

        if (CurrentHealth == 0)
            InvokeKnokedDown();
        else
        {
            StartCoroutine(InvokeHittedAnimatond(2f));
            Rotator.StartMoving();
        }
    }

    private void OnEnable() =>
        _rope.enabled = true;

    private void OnDisable() =>
        _rope.enabled = false;

    private IEnumerator InvokeHittedAnimatond(float time)
    {
        yield return new WaitForSeconds(time);
        OnHittedAnimationEnd();
    }
}
using UnityEngine;
using System.Collections;

public class Enemy : Slaper
{
    public override bool IsCurrentSlaper
    {
        get => base.IsCurrentSlaper;
        set
        {
            base.IsCurrentSlaper = value;
            if (IsCurrentSlaper)
                StartCoroutine(SlapWithDelay(Random.Range(1.5f, 2)));
        }
    }
    public override int Damage => (int)(_baseDamage * Random.Range(0.5f, 1f));
    
    private void Start() =>
        Initialize();
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Slaper>(out Slaper opponent))
            return;

        InvokeSlapeTriggerEnter(opponent);
    }

    private IEnumerator SlapWithDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Slap();
    }

}


using UnityEngine;

public class Enemy : Slaper
{
    public enum EnemyType
    {
        common,
        boss,
        bonus
    }

    public EnemyType Type;

    public ParticleSystem ExplosionVFX;

    public bool UsedArmor = false;

    public override int Damage => (int)(Singletons.Instance.LevelParameters._enemyDamageBase * Random.Range(0.5f, 1));
    public override int MaxHealth => (int)(Singletons.Instance.LevelParameters._enemyHealth);
}
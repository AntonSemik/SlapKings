using UnityEngine;

public class Enemy : Slaper
{
    public bool UsedArmor = false;

    public override int Damage => (int)(Singletons._singletons.LevelParameters._enemyDamageBase * Random.Range(0.5f, 1));
    public override int MaxHealth => (int)(Singletons._singletons.LevelParameters._enemyHealth);
}
using UnityEngine;

[CreateAssetMenu(menuName = "Base Enemy Values", fileName = "New Values")]
public class BaseEnemyValues : ScriptableObject
{
    public int BaseReward = 25;
    public int BonusLevelExtraReward = 75;

    public int BaseHealth = 70;
    public int HealthPerLevel = 30;

    public int BaseDamage = 10;
    public int DamagePerLevel = 25;
}

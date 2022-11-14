using System.Collections.Generic;
public class Player : Slaper
{
    public const string MultiplierSingle = "single";
    public const string MultiplierDouble = "double";
    private PlayerStats _playerStats = new PlayerStats();
    public override int Damage => (int)(_playerStats.Damage);
    public override int MaxHealth => (int)(_playerStats.Health);

    public int DamageMultiplier { get => _damageMultiplier; private set => _damageMultiplier = value; }
    public int DamageDivider { get =>_damageDivider; private set => _damageDivider = value; }
    private int _damageMultiplier = 1;
    private int _damageDivider = 1;
    private Dictionary<string, int> _multiplier = new Dictionary<string, int>() { { MultiplierSingle, 1 }, { MultiplierDouble, 2 } };

    public void SetDamageMultiplier(string multiplier)
        => DamageMultiplier = _multiplier[multiplier];

    public void SetDamageDevider(string multiplier)
        => DamageDivider = _multiplier[multiplier];
}

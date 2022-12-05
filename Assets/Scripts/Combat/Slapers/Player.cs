using System.Collections.Generic;
using UnityEngine;
public class Player : Slaper
{
    [SerializeField] private Transform MegaSlapBone;

    public MegaSlapObject _megaSlapObject;

    public const string NormalSlap = "single"; //Крайне некомфортно, нам надо будет менять множители потом
    public const string MegaSlap = "double";
    public const string ArmorDivider = "Armor";

    private PlayerStats _playerStats = new PlayerStats();
    public override int Damage => (int)(_playerStats.Damage);
    public override int MaxHealth => (int)(_playerStats.Health);
    public float MegaslapTime => (float)(_playerStats.MegaslapTime);

    [HideInInspector]public bool UsedMegaSlap = false;

    public float DamageMultiplier { get => _damageMultiplier; private set => _damageMultiplier = value; }
    public float DamageDivider { get =>_damageDivider; private set => _damageDivider = value; }
    private float _damageMultiplier = 1;
    private float _damageDivider = 1;
    private Dictionary<string, float> _multiplier = new Dictionary<string, float>() { {NormalSlap, 1 }, {MegaSlap, 0.2f}, {ArmorDivider, 2f} };

    public void SetDamageMultiplier(string multiplier)
        => DamageMultiplier = _multiplier[multiplier];

    public void SetDamageDivider(string multiplier)
        => DamageDivider = _multiplier[multiplier];

    public void SetNewMegaSlap(MegaSlapObject newSlap)
    {
        newSlap.Transform.parent = MegaSlapBone;
        newSlap.Transform.localPosition = new Vector3(0, 0, 0);
        newSlap.Transform.localEulerAngles = new Vector3(0, 0, 0);
        newSlap.Transform.localScale = new Vector3(1, 1, 1);

        _megaSlapObject = newSlap;
    }
}
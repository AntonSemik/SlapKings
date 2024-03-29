using System.Collections.Generic;
using UnityEngine;
public class Player : Slaper
{
    [SerializeField] private Transform MegaSlapBone;

    public MegaSlapObject _megaSlapObject;

    private PlayerStats _playerStats = new PlayerStats();
    public override int Damage => (int)(_playerStats.Damage);
    public override int MaxHealth => (int)(_playerStats.Health);
    public float MegaslapTime => _megaSlapObject.MegaslapDuration;
    public float DamageMultiplier => _megaSlapObject.DamageFactor;

    [HideInInspector]public bool UsedMegaSlap = false;

    public const string DefaultValue = "single"; //Heresy.
    public const string HalfProtection = "Division by 2";

    public float DamageDivider { get =>_damageDivider; private set => _damageDivider = value; }
    private float _damageDivider = 1;
    private Dictionary<string, float> _multiplier = new Dictionary<string, float>()
    {
        {DefaultValue, 1 },
        {HalfProtection, 2f}
    };

    public void SetDamageDivider(string multiplier)
        => DamageDivider = _multiplier[multiplier];

    public void SetNewMegaSlap(MegaSlapObject newSlap)
    {
        newSlap.transform.parent = MegaSlapBone;
        newSlap.transform.localPosition = new Vector3(0, 0, 0);
        newSlap.transform.localEulerAngles = new Vector3(0, 0, 0);
        newSlap.transform.localScale = new Vector3(1, 1, 1);

        _megaSlapObject = newSlap;
    }

    public void SetNewDamageDivider (int bonusDefenceCollected)
    {
        float basicDamageDivider = 1.5f;
        DamageDivider = basicDamageDivider + (bonusDefenceCollected * 0.25f);
    }
}
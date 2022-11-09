using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Slaper
{
    // TODO: перенести все UI из Player
    [SerializeField] private Button _slap;
    [SerializeField] private Button _megaSlap;
    [SerializeField] private Button _armorButton;
    [SerializeField] private Indicator _indicator;

    public override int Damage => (int)(_playerStats.Damage * _damageMultiplier * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent));
    public override int MaxHealth => (int)(_playerStats.Health);
    public override bool IsCurrentSlaper
    {
        get => base.IsCurrentSlaper;
        set
        {
            base.IsCurrentSlaper = value;
            _indicator.gameObject.SetActive(IsCurrentSlaper);
            _megaSlap.gameObject.SetActive(IsCurrentSlaper);
            _armorButton.gameObject.SetActive(!IsCurrentSlaper);
            _buttonClicked = !IsCurrentSlaper;
        }
    }
    private bool _buttonClicked;
    
    private Dictionary<string, int> _multiplier = new Dictionary<string, int>() { {"single", 1}, {"double", 2} };
    private int _damageMultiplier;
    private int _damageDivider;

    private PlayerStats _playerStats = new PlayerStats();

    private void Start() =>
         Initialize();
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Slaper>(out Slaper opponent))
            return;

        InvokeSlapeTriggerEnter(opponent);
    }

    protected override void Initialize()
    {
        base.Initialize();
        
        _slap.onClick.AddListener(Slap);
        _megaSlap.onClick.AddListener(MegaSlap);
        _armorButton.onClick.AddListener(SetArmor);
        
        _damageMultiplier = _multiplier["single"];
        _damageDivider = _multiplier["single"];
    }

    protected override void Slap()
    {
        if (!IsCurrentSlaper || _buttonClicked)
            return;

        if (_megaSlap.gameObject.activeSelf)
            _damageMultiplier = _multiplier["single"];

        HideButtons();
        
        base.Slap();
        _buttonClicked = true;
        _indicator.Stop();
    }

    private void MegaSlap()
    {
        _damageMultiplier = _multiplier["double"];;
        _megaSlap.gameObject.SetActive(false);
    }

    public override void ReceiveDamage(int damage)
    {
        damage = damage / _damageDivider;
        base.ReceiveDamage(damage);
        _damageDivider = _multiplier["single"];;
    }

    private void SetArmor()
    {
        _damageDivider = _multiplier["double"];
        _armorButton.gameObject.SetActive(false);
    }

    private void HideButtons()
    {
        _armorButton.gameObject.SetActive(false);
        _megaSlap.gameObject.SetActive(false);
    }
}
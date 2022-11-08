using UnityEngine;
using UnityEngine.UI;

public class Player : Slaper
{
    [SerializeField] private Button _slap;
    [SerializeField] private Button _megaSlap;
    [SerializeField] private Indicator _indicator;
    
    public override int Damage => (int)(_baseDamage * _damageMultiplier * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent));
    public override bool IsCurrentSlaper
    {
        get => base.IsCurrentSlaper;
        set
        {
            base.IsCurrentSlaper = value;
            _indicator.gameObject.SetActive(IsCurrentSlaper);   
            _megaSlap.gameObject.SetActive(IsCurrentSlaper);   
            _buttonClicked = !IsCurrentSlaper;        
        }
    }
    private bool _buttonClicked;
    private int _damageMultiplier = 1;
    
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
    }
    
    protected override void Slap()
    {
        if (!IsCurrentSlaper || _buttonClicked)
            return;
        
        if(_megaSlap.gameObject.activeSelf)
            _damageMultiplier = 1;

        base.Slap();
        _buttonClicked = true;
        _indicator.Stop();        
    }

    private void MegaSlap()
    {
        _damageMultiplier = 2;
        _megaSlap.gameObject.SetActive(false);        
    }
}
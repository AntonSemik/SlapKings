using UnityEngine;
using UnityEngine.UI;

public class Player : Slaper
{
    [SerializeField] private Button _slap;
    [SerializeField] private Indicator _indicator;
    
    public override int Damage => (int)(_baseDamage * Mathf.Lerp(0.5f, 1, _indicator.PowerPercent));
    public override bool IsCurrentSlaper
    {
        get => base.IsCurrentSlaper;
        set
        {
            base.IsCurrentSlaper = value;
            _indicator.gameObject.SetActive(IsCurrentSlaper);   
            _buttonClicked = !IsCurrentSlaper;        
        }
    }
    private bool _buttonClicked;
    
    
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
    }
    protected override void Slap()
    {
        if (!IsCurrentSlaper || _buttonClicked)
            return;
        
        base.Slap();
        _buttonClicked = true;
        _indicator.Stop();
    }



}

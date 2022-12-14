using System.Collections.Generic;
using Currencies;
using Shop;
using UI;
using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons Instance;
    
    [Header("Economy")]
    public Coins Coins;
    public Marshmallows Marshmallows;
    public Dictionary<CurrencyType, Currency> CurrencyManager = new Dictionary<CurrencyType, Currency>();
    public GameShop Shop;
    public Ads AdsPlaceholder;
    [Header("Data")]
    public SaveGameState SaveGameState;
    public LevelParameters LevelParameters;
    [Header("UI")]
    public Indicator Indicator;
    public HitComboIndicator HitComboIndicator;
    public UI.HealthPanelAnimator HealthPanelAnimator;
    [Header("Combat")]
    public GameStateMachine GameStateMachine;
    public PlayerTurn PlayerTurn;
    public ThemeManager ThemeManager;

    [SerializeField] private CurrencyData _coinsData;
    [SerializeField] private CurrencyData _marshmallowsData;
    [SerializeField] private PlayerContainer _playerContainer;

    private void Awake()
    {   
        Instance = this;
        
        ThemeManager.SetThemeUI(ThemeManager.GameThemes.Princess);

        InitCurrencies();
        InitShop();

        // PlayerPrefs.DeleteAll();
        // PREVIOUS LINE IS APOCALIPTICALLY DANGEROUS WTF c. Anton
    }

    private void InitShop()
    {
        Shop.InitGoods(_playerContainer.MegaSlaps);
        Shop.InitGoods(_playerContainer.Players);
    }

    private void InitCurrencies()
    {
        Coins = new Coins(_coinsData);
        Marshmallows = new Marshmallows(_marshmallowsData);
        CurrencyManager.Add(Coins.CurrencyType, Coins);
        CurrencyManager.Add(Marshmallows.CurrencyType, Marshmallows);
    }
}
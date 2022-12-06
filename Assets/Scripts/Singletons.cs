using System.Collections.Generic;
using Currencies;
using Shop;
using UI;
using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons Instance;
    
    public Coins Coins;
    public Marshmallows Marshmallows;
    public Dictionary<CurrencyType, Currency> CurrencyManager = new Dictionary<CurrencyType, Currency>();
    public GameShop Shop;
    public SaveGameState SaveGameState;
    public Ads AdsPlaceholder;
    public LevelParameters LevelParameters;
    public Indicator Indicator;
    public UI.HealthPanelAnimator HealthPanelAnimator;
    public GameStateMachine GameStateMachine;
    public PlayerTurn PlayerTurn;
    public ThemeManager ThemeManager;
    public ExitLocation ExitLocation;

    [SerializeField] private CurrencyData _coinsData;
    [SerializeField] private CurrencyData _marshmallowsData;

    private void Awake()
    {   
        Instance = this;

        InitCurrencies();
        Shop = new GameShop();

        // PlayerPrefs.DeleteAll();
    }

    private void InitCurrencies()
    {
        Coins = new Coins(_coinsData);
        Marshmallows = new Marshmallows(_marshmallowsData);
        CurrencyManager.Add(Coins.CurrencyType, Coins);
        CurrencyManager.Add(Marshmallows.CurrencyType, Marshmallows);
    }
}
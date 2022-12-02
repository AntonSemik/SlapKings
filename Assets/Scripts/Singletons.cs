using System.Collections.Generic;
using Currencies;
using Shop;
using UI;
using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons _singletons;
    
    public Coins Coins;
    public Marshmallows Marshmallows;
    public Skins Skins;
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

    [SerializeField] private CurrencyData _coinsData;
    [SerializeField] private CurrencyData _marshmallowsData;
    [SerializeField] private SkinsData _skinsData;

    private void Awake()
    {   
        _singletons = this;

        InitCurrencies();

        Shop = new GameShop();
        // PlayerPrefs.DeleteAll();
    }

    private void InitCurrencies()
    {
        Coins = new Coins(_coinsData);
        Marshmallows = new Marshmallows(_marshmallowsData);
        Skins = new Skins(_skinsData);
        CurrencyManager.Add(Coins.CurrencyType, Coins);
        CurrencyManager.Add(Marshmallows.CurrencyType, Marshmallows);
        // CurrencyManager.Add(Skins.CurrencyType, Skins);
        Debug.Log(CurrencyManager);
    }
}
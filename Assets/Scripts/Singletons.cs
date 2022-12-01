using System.Collections.Generic;
using Currencies;
using UI;
using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons _singletons;
    
    public Coins Coins;
    public Marshmallows Marshmallows;
    public Dictionary<CurrencyType, Currency> CurrencyManager = new Dictionary<CurrencyType, Currency>();
    public Shop Shop;
    public SaveGameState SaveGameState;
    public Ads AdsPlaceholder;
    public LevelParameters LevelParameters;
    public Indicator Indicator;
    public UI.HealthPanelAnimator HealthPanelAnimator;
    public GameStateMachine GameStateMachine;
    public PlayerTurn PlayerTurn;
    public ThemeManager ThemeManager;

    private void Awake()
    {   
        _singletons = this;

        Coins = new Coins();
        Marshmallows = new Marshmallows();
        CurrencyManager.Add(Coins.CurrencyType, Coins);
        CurrencyManager.Add(Marshmallows.CurrencyType, Marshmallows);
        Shop = new Shop();
    }
}
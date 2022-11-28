using UI;
using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons _singletons;

    public Coins Coins;
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
        PlayerPrefs.DeleteAll();
    }
}
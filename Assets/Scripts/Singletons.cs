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
    private void Awake()
    {   
        SaveGameState.SaveInt("Level",3);
        SaveGameState.SaveInt("DamageLevel",3);
        SaveGameState.SaveInt("HealthLevel",3);
        _singletons = this;
    }
}
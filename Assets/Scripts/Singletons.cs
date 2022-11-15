using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons _singletons;

    public Coins Coins;
    public SaveGameState SaveGameState;
    public AdsPlaceholder AdsPlaceholder;    
    public LevelParameters LevelParameters;
    public Indicator Indicator;
    public UI.HealthPanelAnimator HealthPanelAnimator;
    public GameStateMachine GameStateMachine;
    private void Awake()
    {   
        
        _singletons = this;
    }
}
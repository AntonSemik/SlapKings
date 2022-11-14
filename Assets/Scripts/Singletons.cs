using UnityEngine;

public class Singletons : MonoBehaviour
{
    public static Singletons _s;

    public Coins Coins;
    public SaveGameState SaveGameState;
    public AdsPlaceholder AdsPlaceholder;    
    public LevelParameters LevelParameters;
    public Indicator Indicator;
    public UI.HealthPanelAnimator HealthPanelAnimator;
    public GameStateMachine GameStateMachine;
    private void Awake()
    {   
        
        _s = this;
    }
}

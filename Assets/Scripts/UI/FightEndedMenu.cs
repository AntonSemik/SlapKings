using UnityEngine;

public class FightEndedMenu : MonoBehaviour
{
    [SerializeField] private GameObject _LoseMenu;
    [SerializeField] private GameObject _WinMenu;
    [SerializeField] private GameObject _extraSlapButton;
    [SerializeField] private GameObject _extraRewardButton;

    private void Start()
    {
        Singletons._singletons.GameStateMachine.LevelComplete += OpenWinMenu;
        Singletons._singletons.GameStateMachine.LevelFailed += OpenLoseMenu;
    }

    public void ExtraReward()
    {
        _extraRewardButton.SetActive(false);

        Singletons._singletons.AdsPlaceholder.ShowAd();
        Singletons._singletons.Coins.GiveReward(4);

        _WinMenu.SetActive(false);

        Singletons._singletons.GameStateMachine.IncreaseLevel();
    }

    public void PlusOneSlap()
    {
        _extraSlapButton.SetActive(false);

        Singletons._singletons.AdsPlaceholder.ShowAd();
        Singletons._singletons.PlayerTurn.StartTurn();
        Singletons._singletons.GameStateMachine.TookExtraSlap = true;
        Singletons._singletons.GameStateMachine.Player.ResetSlaper(false); 

        _LoseMenu.SetActive(false);
    }

    public void NoThanks()
    {
        Singletons._singletons.AdsPlaceholder.ShowAd();
        
        if (_WinMenu.activeSelf)
            Singletons._singletons.GameStateMachine.IncreaseLevel(); 
        else if (_LoseMenu.activeSelf)
            Singletons._singletons.GameStateMachine.ReloadLevel();
        
        _WinMenu.SetActive(false);
        _LoseMenu.SetActive(false);
    }
    
    private void OpenWinMenu()
    {
        _WinMenu.SetActive(true);
        _extraRewardButton.SetActive(true);
    }

    private void OpenLoseMenu()
    {
        _LoseMenu.SetActive(true);

        if (!Singletons._singletons.GameStateMachine.TookExtraSlap)
        {
            _extraSlapButton.SetActive(true);
        }
    }
}
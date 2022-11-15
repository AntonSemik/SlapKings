using UnityEngine;

public class FightEndedMenu : MonoBehaviour
{
    [SerializeField] private GameObject _LoseMenu;
    [SerializeField] private GameObject _extraSlapButton;
    [SerializeField] private GameObject _WinMenu;
    [SerializeField] private GameObject _extraRewardButton;

    private void Start()
    {
        Singletons._singletons.GameStateMachine.LevelComplete += OpenWinMenu;
        Singletons._singletons.GameStateMachine.LevelFailed += OpenLoseMenu;
    }

    public void ExtraReward()
    {
        _extraRewardButton.SetActive(false);

        Singletons._singletons.Coins.GiveReward(4);

        _WinMenu.SetActive(false);       
    }

    public void PlusOneSlap()
    {
        _extraSlapButton.SetActive(false);

        Singletons._singletons.AdsPlaceholder.ShowAd();

        Debug.Log("No slaps for you");

        _LoseMenu.SetActive(false);       
    }

    public void NoThanks()
    {
        Singletons._singletons.AdsPlaceholder.ShowAd();

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
        _extraSlapButton.SetActive(true);
    }
}

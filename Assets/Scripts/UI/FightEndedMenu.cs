using UnityEngine;

public class FightEndedMenu : MonoBehaviour
{
    [SerializeField] private GameObject _LoseMenu;
    [SerializeField] private GameObject _extraSlapButton;
    [SerializeField] private GameObject _WinMenu;
    [SerializeField] private GameObject _extraRewardButton;

    private void Start()
    {
        Singletons._s.GameStateMachine.LevelComplete += OpenWinMenu;
        Singletons._s.GameStateMachine.LevelFailed += OpenLoseMenu;
    }

    public void ExtraReward()
    {
        _extraRewardButton.SetActive(false);

        Singletons._s.Coins.GiveReward(4);

        _WinMenu.SetActive(false);       
    }

    public void PlusOneSlap()
    {
        _extraSlapButton.SetActive(false);

        Singletons._s.AdsPlaceholder.ShowAd();

        Debug.Log("No slaps for you");

        _LoseMenu.SetActive(false);       
    }

    public void NoThanks()
    {
        Singletons._s.AdsPlaceholder.ShowAd();

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

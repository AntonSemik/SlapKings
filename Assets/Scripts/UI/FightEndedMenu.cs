using UnityEngine;

public class FightEndedMenu : MonoBehaviour
{
    [SerializeField] private GameObject _LoseMenu;
    [SerializeField] private GameObject _WinMenu;
    [SerializeField] private GameObject _extraSlapButton;
    [SerializeField] private GameObject _extraRewardButton;

    private void Start()
    {
        Singletons.Instance.GameStateMachine.LevelComplete += OpenWinMenu;
        Singletons.Instance.GameStateMachine.LevelFailed += OpenLoseMenu;
    }

    public void ExtraReward()
    {
        _extraRewardButton.SetActive(false);

        Singletons.Instance.AdsPlaceholder.ShowAd();
        Singletons.Instance.Coins.GiveReward(4);

        _WinMenu.SetActive(false);

        Singletons.Instance.GameStateMachine.IncreaseLevel();
    }

    public void PlusOneSlap()
    {
        _extraSlapButton.SetActive(false);

        Singletons.Instance.AdsPlaceholder.ShowAd();
        Singletons.Instance.PlayerTurn.StartTurn();
        Singletons.Instance.GameStateMachine.TookExtraSlap = true;
        Singletons.Instance.GameStateMachine.Player.ResetSlaper(false); 

        _LoseMenu.SetActive(false);
    }

    public void NoThanks()
    {
        Singletons.Instance.AdsPlaceholder.ShowAd();
        
        if (_WinMenu.activeSelf)
            Singletons.Instance.GameStateMachine.IncreaseLevel(); 
        else if (_LoseMenu.activeSelf)
            Singletons.Instance.GameStateMachine.ReloadLevel();
        
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

        if (!Singletons.Instance.GameStateMachine.TookExtraSlap)
        {
            _extraSlapButton.SetActive(true);
        }
    }
}
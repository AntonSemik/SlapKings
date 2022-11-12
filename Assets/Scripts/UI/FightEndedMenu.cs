using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEndedMenu : MonoBehaviour
{
    public PlaceHolderFightStarter _starter; //Не бейте, это временно

    [SerializeField] private GameObject _LoseMenu;
    [SerializeField] private GameObject _extraSlapButton;
    [SerializeField] private GameObject _WinMenu;
    [SerializeField] private GameObject _extraRewardButton;

    private void Start()
    {
        Singletons._s.Fight.PlayerWin += OpenEndMenu;
    }

    public void OpenEndMenu(bool _isPlayerWon)
    {
        if (_isPlayerWon)
        {
            _WinMenu.SetActive(true);
            _extraRewardButton.SetActive(true);
        }
        else
        {
            _LoseMenu.SetActive(true);
            _extraSlapButton.SetActive(true);
        }
    }

    public void ExtraReward()
    {
        _extraRewardButton.SetActive(false);

        Singletons._s.Coins.GiveReward(4);

        _WinMenu.SetActive(false);

        _starter.StartFight();
    }

    public void PlusOneSlap()
    {
        _extraSlapButton.SetActive(false);

        Singletons._s.AdsPlaceholder.ShowAd();

        Debug.Log("No slaps for you");

        _LoseMenu.SetActive(false);

        _starter.StartFight();
    }

    public void NoThanks()
    {
        Singletons._s.AdsPlaceholder.ShowAd();

        _WinMenu.SetActive(false);
        _LoseMenu.SetActive(false);

        _starter.StartFight();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsPlaceholder : MonoBehaviour
{
    [SerializeField] GameObject _placeholderAd;

    [SerializeField]Fight _fight;

    #region testAd
    private void Start()
    {
        _fight.PlayerWin += PlayerWon;
    }

    void PlayerWon(bool _true)
    {
        if (_true)
        {
            ShowAd();
        }
    }
    #endregion

    public void ShowAd()
    {
        _placeholderAd.SetActive(true);
    }

    public void CloseAd()
    {
        _placeholderAd.SetActive(false);
    }
}

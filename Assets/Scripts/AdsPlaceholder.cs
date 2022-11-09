using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsPlaceholder : MonoBehaviour
{
    [SerializeField] GameObject _placeholderAd;

    #region testAd
    private void Start()
    {
        Singletons._s.Fight.PlayerWin += PlayerWon;
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

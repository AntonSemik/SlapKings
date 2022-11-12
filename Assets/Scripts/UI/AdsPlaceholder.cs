using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsPlaceholder : MonoBehaviour
{
    [SerializeField] bool _adsActive = true;
    [SerializeField] GameObject _placeholderAd;

    private void Start()
    {
        _adsActive = Singletons._s.SaveGameState._adsActive;
    }

    public void NoMoreAds()
    {
        _adsActive = false;
        Singletons._s.SaveGameState.SaveInt("AdsActive", _adsActive ? 1 : 0);
    }

    public void ShowAd()
    {
        if (_adsActive)
        {
            _placeholderAd.SetActive(true);
        }
    }

    public void CloseAd()
    {
        _placeholderAd.SetActive(false);
    }
}

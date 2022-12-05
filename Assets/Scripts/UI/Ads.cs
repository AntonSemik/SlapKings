using System;
using UnityEngine;

public class Ads : MonoBehaviour
{
    [SerializeField] GameObject _payment;
    [SerializeField] bool _adsActive = true;
    [SerializeField] GameObject _placeholderAd;
    public event Action AdsOpen; 
    public event Action AdsClose; 

    private void Start()
    {
        _adsActive = Singletons._singletons.SaveGameState._adsActive;
    }

    public void NoMoreAds()
    {
        _payment.SetActive(true);
        _adsActive = false;
        Singletons._singletons.SaveGameState.SaveBool(PlayerPrefsKeys.AdsActiveKey, _adsActive);
    }

    public void ShowAd()
    {
        if (_adsActive)
        {
            _placeholderAd.SetActive(true);
            AdsOpen?.Invoke();
        }
    }

    public void CloseAd()
    {
        _placeholderAd.SetActive(false);
        AdsClose?.Invoke();
    }
}
using System;
using UnityEngine;

public class Ads : MonoBehaviour
{
    [SerializeField] GameObject _payment;
    [SerializeField] bool _ForcedAdsActive = true;
    [SerializeField] GameObject _placeholderAd;
    public event Action AdsOpen; 
    public event Action AdsClose; 

    private void Start()
    {
        _ForcedAdsActive = Singletons.Instance.SaveGameState._adsActive;
    }

    public void DisableForcedAds()
    {
        _payment.SetActive(true);
        _ForcedAdsActive = false;
        Singletons.Instance.SaveGameState.SaveBool(PlayerPrefsKeys.AdsActiveKey, _ForcedAdsActive);
    }

    public void ShowForcedAd()
    {
        if (_ForcedAdsActive)
        {
            _placeholderAd.SetActive(true);
            AdsOpen?.Invoke();
        }
    }

    public void ShowDemandedAd()
    {
        _placeholderAd.SetActive(true);
        AdsOpen?.Invoke();
    }

    public void CloseAd()
    {
        _placeholderAd.SetActive(false);
        AdsClose?.Invoke();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsPlaceholder : MonoBehaviour
{
    // Unity advertisment requires projectID to run, we dont have this for now

    public static AdsPlaceholder _inst;

    [SerializeField] GameObject _placeholderAd;

    [SerializeField]Fight _fight;

    private void Awake()
    {
        _inst = this;
    }

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

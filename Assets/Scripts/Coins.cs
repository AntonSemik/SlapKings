using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsUI;

    public static Coins _inst;
    private int _coins;

    private void Start()
    {
        _inst = this;

        _coins = SaveGameState._inst._coins;
        _coinsUI.text = _coins.ToString();
    }

    public void ChangeCoins(int _amount)
    {
        _coins += _amount;

        SaveGameState._inst.SaveInt("Coins", _coins);

        _coinsUI.text = _coins.ToString();
    }

    public bool IsEnough(int _amountNeeded)
    {
        return _amountNeeded <= _coins;
    }

}

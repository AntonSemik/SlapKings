using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsUI;

    public static Coins _inst;
    private int _coins;

    [SerializeField] private Fight _fight;

    private void Start()
    {
        _inst = this;

        _coins = Singletons._s.SaveGameState._coins;
        _coinsUI.text = _coins.ToString();

        Singletons._s.Fight.PlayerWin += OnFightEnded;
    }

    public void GiveReward(int _multyplier)
    {
        int _reward;
        _reward = Singletons._s.LevelParameters._baseReward * _multyplier;
        ChangeCoins(_reward);

        Debug.Log("Player earned " + _reward.ToString() + " coins");
    }

    void OnFightEnded(bool _isPlayerWin)
    {
        if (_isPlayerWin)
        {
            GiveReward(4);
        }
        else
        {
            GiveReward(1);
        }
    }

    public void ChangeCoins(int _amount)
    {
        _coins += _amount;

        Singletons._s.SaveGameState.SaveInt("Coins", _coins);

        _coinsUI.text = _coins.ToString();
    }

    public bool IsEnough(int _amountNeeded)
    {
        return _amountNeeded <= _coins;
    }

}

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

    void OnFightEnded(bool _isPlayerWin)
    {
        int reward;

        if (_isPlayerWin)
        {
            reward = Singletons._s.LevelParameters.PlayerWon();

            //Check for ad

            ChangeCoins(reward);
        }
        else
        {
            reward = Singletons._s.LevelParameters.PlayerLost();
            ChangeCoins(reward);
        }

        Debug.Log("Player earned " + reward.ToString() + " coins");
    }

    void ChangeCoins(int _amount)
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

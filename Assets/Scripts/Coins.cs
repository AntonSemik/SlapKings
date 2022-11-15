using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _coinsUI;
    private GameStateMachine _stateMachine;
    private int _coins;


    private void Start()
    {
        SetDependencies();

        foreach (TMP_Text text in _coinsUI)
        {
            text.text = _coins.ToString();
        }
    }

    public void GiveReward(int _multyplier)
    {
        int _reward;
        _reward = Singletons._singletons.LevelParameters._baseReward * _multyplier;
        ChangeCoins(_reward);

        Debug.Log("Player earned " + _reward.ToString() + " coins");
    }

    public void ChangeCoins(int _amount)
    {
        _coins += _amount;

        Singletons._singletons.SaveGameState.SaveInt("Coins", _coins);

        foreach (TMP_Text text in _coinsUI)
        {
            text.text = _coins.ToString();
        }
    }

    public bool IsEnough(int _amountNeeded)
    {
        return _amountNeeded <= _coins;
    }

    private void OnLevelComplete() =>
        GiveReward(4);
    private void OnLevelFailed() =>
        GiveReward(1);
    private void SetDependencies()
    {
        _coins = Singletons._singletons.SaveGameState._coins;
        _stateMachine = Singletons._singletons.GameStateMachine;
        _stateMachine.LevelComplete += OnLevelComplete;
        _stateMachine.LevelFailed += OnLevelFailed;
    }
}

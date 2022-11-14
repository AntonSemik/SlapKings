using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsUI;
    private GameStateMachine _stateMachine;
    private int _coins;


    private void Start()
    {
        SetDependencies();
        _coinsUI.text = _coins.ToString();
    }

    public void GiveReward(int _multyplier)
    {
        int _reward;
        _reward = Singletons._s.LevelParameters._baseReward * _multyplier;
        ChangeCoins(_reward);

        Debug.Log("Player earned " + _reward.ToString() + " coins");
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

    private void OnLevelComplete() =>
        GiveReward(4);
    private void OnLevelFailed() =>
        GiveReward(1);
    private void SetDependencies()
    {
        _coins = Singletons._s.SaveGameState._coins;
        _stateMachine = Singletons._s.GameStateMachine;
        _stateMachine.LevelComplete += OnLevelComplete;
        _stateMachine.LevelFailed += OnLevelFailed;
    }
}

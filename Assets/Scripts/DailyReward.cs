using UnityEngine;
using System;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    private DateTime _lastLogInDate;
    private int StrikeDays
    {
        get => PlayerPrefs.GetInt("StrikeDays", 1);
        set => PlayerPrefs.SetInt("StrikeDays", value);
    }
    private int GatheredRewards
    {
        get => PlayerPrefs.GetInt("GatheredReward", 0);
        set => PlayerPrefs.SetInt("GatheredReward", value);
    }
    private string LastLogIn
    {
        get => PlayerPrefs.GetString("LastLogIn", (DateTime.Today).ToString());
        set => PlayerPrefs.SetString("LastLogIn", value);
    }
    [SerializeField] private DailyRewardUIGroup[] _rewards;
    

    private void Start()
    {
        SetRewards();
        LoadLastLogInDate();
        
        if ((DateTime.Today - _lastLogInDate).TotalDays == 1) //DateTime.Today
            StrikeDays += 1;

        else if ((DateTime.Today - _lastLogInDate).TotalDays != 0)
            Reset();

        if (GatheredRewards == 5 || StrikeDays >= 6)
            Reset();

        UpdateUI();

        _lastLogInDate = DateTime.Today;
        SaveLastLogIn();

    }

    public void ClaimReward()
    {
        if (StrikeDays == GatheredRewards)
            return;

        GatheredRewards += 1;
        UpdateUI();
        switch (GatheredRewards)
        {
            case 1:
                Singletons.Instance.Coins.ChangeValue(1000);
                break;

            case 2:
                EnemyTurn.Instance.SetArmor(true);
                break;

            case 3:
                Singletons.Instance.Coins.ChangeValue(5000);
                break;

            case 4:
                EnemyTurn.Instance.SetArmor(true);
                break;

            case 5:
                Singletons.Instance.Marshmallows.ChangeValue(5);
                break;
        }
    }

    private void LoadLastLogInDate()
    {
        string ddmmyyyy = LastLogIn;
        _lastLogInDate = new DateTime
        (
            Int32.Parse(ddmmyyyy.Substring(6, 4)),
            Int32.Parse(ddmmyyyy.Substring(3, 2)),
            Int32.Parse(ddmmyyyy.Substring(0, 2))
        );
    }
    private void SaveLastLogIn() =>
        LastLogIn = _lastLogInDate.ToString().Substring(0, 10);
    private void SetRewards() =>
        _rewards = GetComponentsInChildren<DailyRewardUIGroup>();

    private void StrikeRewards(int amount)
    {
        for (int i = 0; i < amount; i++)
            _rewards[i].StrikeTroughReward(true);
    }
    private void OpenRewards(int amount)
    {
        for (int i = 0; i < amount; i++)
            _rewards[i].Unlock(true);
    }

    private void UpdateUI()
    {
        OpenRewards(StrikeDays);
        StrikeRewards(GatheredRewards);
        ButtonsAdjust();
    }

    private void ButtonsAdjust()
    {
        for (int i = 0; i < GatheredRewards; i++)
            _rewards[i].GetComponent<Button>().enabled = false;

        for (int i = StrikeDays; i < _rewards.Length; i++)
            _rewards[i].GetComponent<Button>().enabled = false;
    }

    private void ResetUI()
    {
        for (int i = 0; i < _rewards.Length; i++)
        {
            _rewards[i].StrikeTroughReward(false);
            _rewards[i].Unlock(false);
        }
    }
    private void Reset()
    {
        StrikeDays = 1;
        GatheredRewards = 0;
        ResetUI();
        ButtonsAdjust();
    }

}

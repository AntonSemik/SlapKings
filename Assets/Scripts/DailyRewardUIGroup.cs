using UnityEngine.UI;
using UnityEngine;

public class DailyRewardUIGroup : MonoBehaviour
{
    [SerializeField] private Image _strikeTrough;
    [SerializeField] private Image _loked;

    public void StrikeTroughReward(bool show)
        => _strikeTrough.enabled = show;

    public void Unlock(bool unlock)
       => _loked.enabled = !unlock;
}

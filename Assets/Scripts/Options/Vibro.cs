using UnityEngine.UI;
using UnityEngine;

public class Vibro : MonoBehaviour
{
    public static Vibro _inst; // Vibro._inst._isVibroOff to get vibro state

    [SerializeField] private Toggle _toggleVibroUI;

    public bool _isVibroOff { private set; get; }

    private void Start()
    {
        _inst = this;

        _isVibroOff = Singletons.Instance.SaveGameState._vibroOff;
        if (_toggleVibroUI.isOn != _isVibroOff)
        {
            _toggleVibroUI.isOn = _isVibroOff;
            ToggleVibro(); //setting toggle UI element triggers ToggleVibro, second call reverts changes
        }
    }

    public void ToggleVibro()
    {
        _isVibroOff = !_isVibroOff;

        Singletons.Instance.SaveGameState.SaveInt(PlayerPrefsKeys.VibrationOffKey, _isVibroOff ? 1 : 0);
    }
}
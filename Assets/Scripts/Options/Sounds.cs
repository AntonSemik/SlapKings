using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    [SerializeField] private Toggle _toggleSoundUI;

    private void Start()
    {
        AudioListener.pause = Singletons.Instance.SaveGameState._soundsPaused;
        if (_toggleSoundUI.isOn != AudioListener.pause)
        {
            _toggleSoundUI.isOn = AudioListener.pause;
            ToggleSounds(); //setting toggle element triggers ToggleSounds, second call reverts changes
        }
    }

    public void ToggleSounds()
    {
        AudioListener.pause = !AudioListener.pause;

        Singletons.Instance.SaveGameState.SaveBool(PlayerPrefsKeys.SoundsPausedKey, AudioListener.pause);
    }
}
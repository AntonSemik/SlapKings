using System;
using UnityEngine;

namespace UI
{
    public class ThemeManager : MonoBehaviour
    {
        public event Action<GameThemes> OnChangeThemeUI;
        public enum GameThemes { King, Princess }

        private const GameThemes defaultTheme = GameThemes.King;
        public GameThemes GameTheme { private set; get; } = defaultTheme;

        private void Awake()
        {
            GameTheme = Singletons.Instance.SaveGameState.GameThemeUI;
        }

        public void SwitchThemeUI()
        {
            GameThemes gameTheme = GameTheme == GameThemes.King ? GameThemes.Princess : GameThemes.King;
            SetThemeUI(gameTheme);
        }

        public void SetThemeUI(GameThemes gameTheme)
        {
            GameTheme = gameTheme;
            Singletons.Instance.SaveGameState.GameThemeUI = GameTheme;
            OnChangeThemeUI?.Invoke(GameTheme);
        }

        public bool IsDefault => Singletons.Instance.ThemeManager.GameTheme == defaultTheme;
        
        #if UNITY_EDITOR
        private void Update()
        {
            if (UnityEngine.Input.GetKeyUp(KeyCode.T))
            {
                SwitchThemeUI();
            }
        }
        #endif
        
    }
}
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
            GameTheme = Singletons._singletons.SaveGameState.GameThemeUI;
        }

        public void SwitchThemeUI()
        {
            GameThemes gameTheme = GameTheme == GameThemes.King ? GameThemes.Princess : GameThemes.King;
            SetThemeUI(gameTheme);
        }

        public void SetThemeUI(GameThemes gameTheme)
        {
            GameTheme = gameTheme;
            Singletons._singletons.SaveGameState.GameThemeUI = GameTheme;
            OnChangeThemeUI?.Invoke(GameTheme);
        }

        public bool IsDefault => Singletons._singletons.ThemeManager.GameTheme == defaultTheme;
        
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
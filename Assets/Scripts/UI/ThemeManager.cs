using System;
using UnityEngine;

namespace UI
{
    public class ThemeManager : MonoBehaviour
    {
        public event Action ChangeThemeUI;
        public enum GameThemes { King, Princess }
        public GameThemes GameTheme { private set; get; } = GameThemes.King;

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
            ChangeThemeUI?.Invoke();
        }
        
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
using System;
using UnityEngine;

namespace UI
{
    public class ThemeManager : MonoBehaviour
    {
        public event Action ChangeThemeUI;
        public enum Themes { King, Princess }
        public Themes GameTheme { private set; get; } = Themes.King;

        public void SwitchThemeUI()
        {
            Themes theme = GameTheme == Themes.King ? Themes.Princess : Themes.King;
            SetThemeUI(theme);
        }

        public void SetThemeUI(Themes theme)
        {
            GameTheme = theme;
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
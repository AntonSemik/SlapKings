using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ThemesDisableObject : MonoBehaviour
    {
        private int _currentThemeIndex;

        private void Start()
        {
            SubscribeOnChangeThemeUI();
            ChangeThemeUI(Singletons.Instance.ThemeManager.GameTheme);
        }

        private void ChangeThemeUI(ThemeManager.GameThemes gameTheme)
        {
            int themeIndex = (int) gameTheme;
            if (themeIndex == _currentThemeIndex) return;
            gameObject.SetActive(false);
            _currentThemeIndex = themeIndex;
        }

        private void SubscribeOnChangeThemeUI()
        {
            Singletons.Instance.ThemeManager.OnChangeThemeUI += ChangeThemeUI;
        }
        
        private void UnSubscribeOnChangeThemeUI()
        {
            Singletons.Instance.ThemeManager.OnChangeThemeUI -= ChangeThemeUI;
        }

        private void OnDestroy()
        {
            UnSubscribeOnChangeThemeUI();
        }
    }
}
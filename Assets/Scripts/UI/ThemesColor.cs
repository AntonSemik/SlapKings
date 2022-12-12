using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ThemesColor : MonoBehaviour
    {
        [SerializeField] private List<Color> _colors;

        private int _currentThemeIndex;
        private Image _image;
        private bool _canChangeTheme;

        private void Start()
        {
            SubscribeOnChangeThemeUI();
            InitDefaultTheme();
            ChangeThemeUI(Singletons.Instance.ThemeManager.GameTheme);
        }

        private void InitDefaultTheme()
        {
            _image = GetComponent<Image>();
            if (_image != null)
            {
                _colors.Insert(0, _image.color);
                _canChangeTheme = true;
            }
        }

        private void ChangeThemeUI(ThemeManager.GameThemes gameTheme)
        {
            if (!_canChangeTheme) return;

            int themeIndex = (int) gameTheme;
            if (themeIndex > _colors.Count - 1) return;
            if (themeIndex == _currentThemeIndex) return;
            
            _image.color = _colors[themeIndex];
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
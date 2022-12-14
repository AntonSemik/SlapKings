using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ThemesTextColor : MonoBehaviour
    {
        [SerializeField] private List<Color> _colors;

        private int _currentThemeIndex;
        private TMP_Text _text;
        private bool _canChangeTheme;

        private void Start()
        {
            SubscribeOnChangeThemeUI();
            InitDefaultTheme();
            ChangeThemeUI(Singletons.Instance.ThemeManager.GameTheme);
        }

        private void InitDefaultTheme()
        {
            _text = GetComponent<TMP_Text>();
            if (_text != null)
            {
                _colors.Insert(0, _text.color);
                _canChangeTheme = true;
            }
        }

        private void ChangeThemeUI(ThemeManager.GameThemes gameTheme)
        {
            if (!_canChangeTheme) return;

            int themeIndex = (int) gameTheme;
            if (themeIndex > _colors.Count - 1) return;
            if (themeIndex == _currentThemeIndex) return;
            
            _text.color = _colors[themeIndex];
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
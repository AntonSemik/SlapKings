using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ThemesScale : MonoBehaviour
    {
        [SerializeField] private List<Vector3> _scale;

        private int _currentThemeIndex;
        private RectTransform _rectTransform;
        private bool _canChangeTheme;

        private void Start()
        {
            SubscribeOnChangeThemeUI();
            InitDefaultTheme();
            ChangeThemeUI(Singletons.Instance.ThemeManager.GameTheme);
        }

        private void InitDefaultTheme()
        {
            _rectTransform = GetComponent<RectTransform>();
            if (_rectTransform != null)
            {
                _scale.Insert(0, _rectTransform.localScale);
                _canChangeTheme = true;
            }
        }

        private void ChangeThemeUI(ThemeManager.GameThemes gameTheme)
        {
            if (!_canChangeTheme) return;

            int themeIndex = (int) gameTheme;
            if (themeIndex > _scale.Count - 1) return;
            if (themeIndex == _currentThemeIndex) return;
            
            _rectTransform.localScale = _scale[themeIndex];
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
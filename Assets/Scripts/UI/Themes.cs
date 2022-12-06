using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Themes : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _sprites;

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
                _sprites.Insert(0, _image.sprite);
                _canChangeTheme = true;
            }
        }

        private void ChangeThemeUI(ThemeManager.GameThemes gameTheme)
        {
            if (!_canChangeTheme) return;

            int themeIndex = (int) gameTheme;
            if (themeIndex > _sprites.Count - 1) return;
            if (themeIndex == _currentThemeIndex) return;
            
            _image.sprite = _sprites[themeIndex];
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
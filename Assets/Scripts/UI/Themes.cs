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
            InitDefautTheme();
            OnChangeThemeUI();
        }

        private void InitDefautTheme()
        {
            _image = GetComponent<Image>();
            if (_image != null)
            {
                _sprites.Insert(0, _image.sprite);
                _canChangeTheme = true;
            }
        }

        private void OnChangeThemeUI()
        {
            if (!_canChangeTheme) return;

            int themeIndex = (int) Singletons._singletons.ThemeManager.GameTheme;
            if (themeIndex > _sprites.Count - 1) return;
            if (themeIndex == _currentThemeIndex) return;
            
            _image.sprite = _sprites[themeIndex];
            _currentThemeIndex = themeIndex;
        }

        private void SubscribeOnChangeThemeUI()
        {
            Singletons._singletons.ThemeManager.ChangeThemeUI += OnChangeThemeUI;
        }
    }
}
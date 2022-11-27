using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Themes : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _sprites;

        private int _currentTheme;
        private int _defaultTheme;
        private Image _image;

        private bool _canChangeTheme;
        
        private void Awake()
        {
            _image = GetComponent<Image>();
            if (_image != null)
            {
                _sprites.Insert(0, _image.sprite);
                _canChangeTheme = true;
            }
            // _sprites.Add(_image.sprite);
            // _defaultTheme = _sprites.Count - 1;
            // _currentTheme = _defaultTheme == 0 ? 0 : _defaultTheme;
            // _currentTheme = _defaultTheme == 0 ? 0 : _defaultTheme - 1;
            // _currentTheme = 0;
            // _image.sprite = _sprites[_currentTheme];
        }

        private void Start()
        {
            SubscribeOnChangeThemeUI();
        }

        private void OnDisable()
        {
            UnSubscribeOnChangeThemeUI();
        }

        private void OnChangeThemeUI(int indexTheme)
        {
            if (!_canChangeTheme) return;
            // if (indexTheme > _sprites.Count)
            // TODO: check item in list
            
            _image.sprite = _sprites[indexTheme];
            // Debug.Log(_sprites[3]);
        }

        private void SubscribeOnChangeThemeUI()
        {
            Singletons._singletons.LevelParameters.ChangeThemeUI += OnChangeThemeUI;
        }
        
        private void UnSubscribeOnChangeThemeUI()
        {
            Singletons._singletons.LevelParameters.ChangeThemeUI -= OnChangeThemeUI;
        }
        
    }
}
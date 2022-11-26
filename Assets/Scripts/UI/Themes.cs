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
        
        private void Awake()
        {
            _image = GetComponent<Image>();
            _sprites.Add(_image.sprite);
            _defaultTheme = _sprites.Count - 1;
            // _currentTheme = _defaultTheme == 0 ? 0 : _defaultTheme - 1;
            _currentTheme = 0;
            _image.sprite = _sprites[_currentTheme];
        }
    }
}
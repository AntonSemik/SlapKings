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
            
        }

        private void OnEnable()
        {
            // TODO: скрытая win панель
            
            // _image = GetComponent<Image>();
            // if (_image != null)
            // {
            //     _sprites.Insert(0, _image.sprite);
            //     _canChangeTheme = true;
            // }
            // Debug.Log(gameObject.SetActive());
            // Debug.Log(Singletons._singletons.LevelParameters.GetTheme());
            // if (Singletons._singletons.LevelParameters.GetTheme() != null)
                // OnChangeThemeUI();
        }

        private void Start()
        {
            SubscribeOnChangeThemeUI();
            // Debug.Log(Singletons._singletons.LevelParameters.GameTheme);
            
            _image = GetComponent<Image>();
            if (_image != null)
            {
                _sprites.Insert(0, _image.sprite);
                _canChangeTheme = true;
            }
            // Debug.Log(gameObject.name);
            OnChangeThemeUI();
        }

        private void OnChangeThemeUI()
        {
            if (!_canChangeTheme) return;

            int indexTheme = (int) Singletons._singletons.LevelParameters.GameTheme;
            if (indexTheme > _sprites.Count - 1) return;
            
            _image.sprite = _sprites[indexTheme];
            Debug.Log("OnChangeThemeUI " + Singletons._singletons.LevelParameters.GameTheme);
        }

        private void SubscribeOnChangeThemeUI()
        {
            Singletons._singletons.LevelParameters.ChangeThemeUI += OnChangeThemeUI;
        }
        
        private void UnSubscribeOnChangeThemeUI()
        {
            Singletons._singletons.LevelParameters.ChangeThemeUI -= OnChangeThemeUI;
        }
        
        private void OnDisable()
        {
            UnSubscribeOnChangeThemeUI();
        }
        
    }
}
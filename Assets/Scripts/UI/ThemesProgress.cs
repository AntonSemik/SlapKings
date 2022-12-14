using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ThemesProgress : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _sprites;

        private int _currentThemeIndex;
        private ProgressLevel _progress;
        private bool _canChangeTheme;

        private void Start()
        {
            SubscribeOnChangeThemeUI();
            InitDefaultTheme();
            ChangeThemeUI(Singletons.Instance.ThemeManager.GameTheme);
            _progress.OnEnable();
        }

        private void InitDefaultTheme()
        {
            _progress = GetComponent<ProgressLevel>();
        }

        private void ChangeThemeUI(ThemeManager.GameThemes gameTheme)
        {
            int themeIndex = (int) gameTheme;
            if (themeIndex > _sprites.Count - 1) return;
            if (themeIndex == _currentThemeIndex) return;
            _progress.SetProgressSprites(_sprites);
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
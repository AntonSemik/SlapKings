using System;
using Currencies;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class CurrencyObserver : MonoBehaviour
    {
        [SerializeField] private CurrencyType currencyType;
        private TMP_Text _currency;

        private void Awake()
        {
            _currency = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            Singletons._singletons.CurrencyManager[currencyType].OnChanged += UpdateText;
            Singletons._singletons.ThemeManager.OnChangeThemeUI += ChangeThemeUI;

            gameObject.SetActive(!CanToggleActive());
            
            UpdateText(Singletons._singletons.CurrencyManager[currencyType].Total);
        }

        private bool CanToggleActive()
        {
            return currencyType != CurrencyType.Coins && Singletons._singletons.ThemeManager.GameTheme != ThemeManager.GameThemes.Princess;
        }

        private void ChangeThemeUI(ThemeManager.GameThemes theme)
        {
            gameObject.SetActive(!CanToggleActive());  
        }

        private void UpdateText(int value)
        {
            _currency.text = value.ToString();
        }

        private void OnDestroy()
        {
            Singletons._singletons.CurrencyManager[currencyType].OnChanged -= UpdateText;
            Singletons._singletons.ThemeManager.OnChangeThemeUI -= ChangeThemeUI;
        }
    }
}
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
        [SerializeField] private bool _dontToggle;
        private TMP_Text _currency;

        private void Awake()
        {
            _currency = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            Singletons.Instance.CurrencyManager[currencyType].OnChanged += UpdateText;
            Singletons.Instance.ThemeManager.OnChangeThemeUI += ChangeThemeUI;

            gameObject.SetActive(!CanToggleActive());
            
            UpdateText(Singletons.Instance.CurrencyManager[currencyType].Total);
        }

        private bool CanToggleActive()
        {
            if (_dontToggle) return false;
            return currencyType != CurrencyType.Coins && Singletons.Instance.ThemeManager.IsDefault;
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
            Singletons.Instance.CurrencyManager[currencyType].OnChanged -= UpdateText;
            Singletons.Instance.ThemeManager.OnChangeThemeUI -= ChangeThemeUI;
        }
    }
}
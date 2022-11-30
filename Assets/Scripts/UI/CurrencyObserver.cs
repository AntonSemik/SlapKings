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
            UpdateText(Singletons._singletons.CurrencyManager[currencyType].Total);
        }

        private void UpdateText(int value)
        {
            _currency.text = value.ToString();
        }

        private void OnDestroy()
        {
            Singletons._singletons.CurrencyManager[currencyType].OnChanged -= UpdateText;
        }
    }
}
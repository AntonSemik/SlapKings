using System;
using Currencies;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class CurrencyObserver : MonoBehaviour
    {
        private TMP_Text _currency;

        private void Awake()
        {
            _currency = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            Singletons._singletons.Coins.OnChanged += UpdateText;
            UpdateText(Singletons._singletons.Coins.Total);
        }

        private void UpdateText(int value)
        {
            _currency.text = value.ToString();
        }

        private void OnDestroy()
        {
            Singletons._singletons.Coins.OnChanged -= UpdateText;
        }
    }
}
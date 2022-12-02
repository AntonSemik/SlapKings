using System;
using Currencies;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Shop
{
    [RequireComponent(typeof(Button))]
    public class BuyButton : MonoBehaviour
    {
        [SerializeField] protected CurrencyData _whatsBuySettings;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _coin;
        [SerializeField] private TMP_Text _price;

        private Button _button;
        private Currency _whatsBuy;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Buy);
            
            _title.text = _whatsBuySettings.title;
            _price.text = _whatsBuySettings.price.ToString();
            _icon.sprite = _whatsBuySettings.icon;
            _coin.sprite = Singletons._singletons.CurrencyManager[_whatsBuySettings.buyingPerCurrency].Settings.icon;
            
            GetWhatsBuy();
        }

        protected virtual void GetWhatsBuy()
        {
            _whatsBuy = Singletons._singletons.CurrencyManager[_whatsBuySettings.currencyType];
        }

        protected virtual void Buy()
        {
            Singletons._singletons.Shop.Buy(_whatsBuy);
        }
        
        
    }
}
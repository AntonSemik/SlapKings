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
        public CurrencyData whatsBuySettings;
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
            
            _title.text = whatsBuySettings.title;
            _price.text = whatsBuySettings.price.ToString();
            _icon.sprite = whatsBuySettings.icon;
            _coin.sprite = Singletons.Instance.CurrencyManager[whatsBuySettings.buyingPerCurrency].Settings.icon;
            
            GetWhatsBuy();
        }

        protected virtual void GetWhatsBuy()
        {
            _whatsBuy = Singletons.Instance.CurrencyManager[whatsBuySettings.currencyType];
        }

        protected virtual void Buy()
        {
            Singletons.Instance.Shop.Buy(_whatsBuy);
        }
        
        
    }
}
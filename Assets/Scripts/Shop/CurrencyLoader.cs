using System;
using Currencies;
using UnityEngine;

namespace Shop
{
    public class CurrencyLoader : MonoBehaviour
    {
        [SerializeField] private BuyButton _buttonPrefab;
        [SerializeField] private CurrencyType _currencyType;
        
        private void Awake()
        {
            if (!Singletons._singletons.Shop.Goods.ContainsKey(_currencyType)) return;
            foreach (var settings in Singletons._singletons.Shop.Goods[_currencyType])
            {
                _buttonPrefab._whatsBuySettings = settings;
                Instantiate(_buttonPrefab, transform);
            }
        }
    }
}
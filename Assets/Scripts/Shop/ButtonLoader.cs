using System;
using Currencies;
using UnityEngine;

namespace Shop
{
    public class ButtonLoader : MonoBehaviour
    {
        [SerializeField] private BuyButton _buttonPrefab;
        [SerializeField] private CurrencyType _currencyType;
        
        private void Awake()
        {
            foreach (var button in Singletons._singletons.Shop.GoodsButtons[_currencyType])
            {
                button.transform.SetParent(transform);
                button.transform.localScale = Vector3.one;
            }
        }
    }
}